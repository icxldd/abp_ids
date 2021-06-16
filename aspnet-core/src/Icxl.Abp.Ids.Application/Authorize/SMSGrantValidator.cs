using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Icxl.Abp.Ids.Authorize
{
    public class SMSGrantValidator : IExtensionGrantValidator, ITransientDependency
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IdentityUserManager _userManager;
        private readonly IGuidGenerator _guild;

        public SMSGrantValidator(IIdentityUserRepository userRepository, IdentityUserManager userManager,
            IGuidGenerator guild)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _guild = guild;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var phoneNumber = context.Request.Raw.Get("phoneNumber");
            var verifyCode = context.Request.Raw.Get("verifyCode");

            var verifResult = true;
            if (verifResult)
            {
                var result = await _userRepository.GetListAsync(x => x.PhoneNumber == phoneNumber);
                bool countZero = result.Count == 0;
                string loginId = countZero ? "" : result[0].Id.ToString();
                if (countZero)
                {
                    var newGuid = _guild.Create();
                    var inputEntity = new IdentityUser(newGuid,
                        $"{new Random().Next(1000000).GetHashCode()}",
                        $"{new Random().Next(1000000).GetHashCode()}@qq.com");
                    inputEntity.SetPhoneNumber(phoneNumber, true);
                    var resultUser = await _userManager.CreateAsync(inputEntity);
                    if (resultUser.Succeeded)
                    {
                        loginId = newGuid.ToString();
                    }
                }

                context.Result = new GrantValidationResult(
                    subject: loginId,
                    authenticationMethod: ExtensionGrantTypes.SMSGrantType,
                    claims: null);
            }
            else
            {
                var errorValidationResult = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
                errorValidationResult.ErrorDescription = "验证码错误。";
                context.Result = errorValidationResult;
            }
        }

        public string GrantType => ExtensionGrantTypes.SMSGrantType;
    }
}