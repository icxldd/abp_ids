using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Identity;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Icxl.Abp.Ids.Authorize.Impl
{
    public abstract class BaseOAuthService : IdsAppService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public BaseOAuthService(
            IdentityUserManager identityUserManager,
            UserManager<Volo.Abp.Identity.IdentityUser> userManager
        )
        {
            _userManager = userManager;
        }

        protected async Task<string> GenerateToken(Volo.Abp.Identity.IdentityUser user,
            string selectedProvider = "Phone")
        {
            var code = await _userManager.GenerateTwoFactorTokenAsync(user, selectedProvider);
            return code;
        }
    }
}