using System;
using System.Threading.Tasks;
using Icxl.Abp.Ids.Users;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using System.Linq;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace Icxl.Abp.Ids.Authorize.ExtensionGrants
{
    public class QQGrantValidator : IExtensionGrantValidator, ITransientDependency
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IdentityUserManager _userManager;
        private readonly IGuidGenerator _guild;
        private readonly IBasicRepository<AppUser, Guid> _appUserRepository;

        public QQGrantValidator(IIdentityUserRepository userRepository, IdentityUserManager userManager,
            IGuidGenerator guild, IBasicRepository<AppUser, Guid> appUserRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _guild = guild;
            _appUserRepository = appUserRepository;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var qq = context.Request.Raw.Get("qq");
            var sex = Enum.Parse<IdsAuthConst.ESex>(context.Request.Raw.Get("sex"));
            {
                var result = (await _appUserRepository.GetListAsync(x => x.QQ == qq));

                if (result.Count > 0)
                {
                    AppUser user = result[0];
                    context.Result = new GrantValidationResult(
                        subject: user.Id.ToString(),
                        authenticationMethod: ExtensionGrantTypes.QQGrantType,
                        claims: null);
                }
                //注册
                else
                {
                    Guid newGuid = _guild.Create();
                    string name = $"{new Random().Next(1000000).GetHashCode()}",
                        email = $"{new Random().Next(1000000).GetHashCode()}@qq.com";

                    var inputEntity = new AppUser(newGuid, email, name, qq, (int) sex);
                    await _appUserRepository.InsertAsync(inputEntity, true);
                    {
                        context.Result = new GrantValidationResult(
                            subject: newGuid.ToString(),
                            authenticationMethod: ExtensionGrantTypes.QQGrantType,
                            claims: null);
                    }
                }
            }
        }

        public string GrantType => ExtensionGrantTypes.QQGrantType;
    }
}