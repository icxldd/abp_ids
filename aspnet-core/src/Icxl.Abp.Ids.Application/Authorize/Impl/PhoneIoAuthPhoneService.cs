using System;
using System.Threading.Tasks;
using Icxl.Abp.Ids.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.Identity;
using Flurl;
using Flurl.Http;

namespace Icxl.Abp.Ids.Authorize.Impl
{
    public class PhoneIoAuthPhoneService : BaseOAuthService, IOAuthPhoneSerivce
    {
        private readonly IConfiguration _configuration;
        private readonly AppConfigOptions _appconfig;

        public PhoneIoAuthPhoneService(IdentityUserManager identityUserManager,
            Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager,
            IOptions<AppConfigOptions> appConfig
        ) : base(identityUserManager,
            userManager)
        {
            _appconfig = appConfig.Value;
        }

        public async Task<IdsConnectTokenDto> LoginByPhoneNumber(string phone, string verifyCode)
        {
            string url = _appconfig.AuthServer.Authority;
            string LoginUrl = url + IdsLoginConst.LOGIN_CONNECT_URL;
            var val = await LoginUrl
                .PostUrlEncodedAsync(IdsLoginBuilder.BuilberPhoneLogin(phone, verifyCode));
            var obj = await val.GetJsonAsync<IdsConnectTokenDto>();
            return obj;
        }
    }
}