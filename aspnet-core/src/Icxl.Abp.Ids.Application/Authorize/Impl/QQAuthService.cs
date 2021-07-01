using System.Threading.Tasks;
using Flurl.Http;
using Icxl.Abp.Ids.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Volo.Abp.Identity;

namespace Icxl.Abp.Ids.Authorize.Impl
{
    public class QQAuthService : BaseOAuthService, IQQOAuthSerivce
    {
        private readonly AppConfigOptions _appconfig;

        public QQAuthService(IdentityUserManager identityUserManager,
            Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager,
            IOptions<AppConfigOptions> appConfig
        ) : base(identityUserManager,
            userManager)
        {
            _appconfig = appConfig.Value;
        }


        public async Task<IdsConnectTokenDto> LoginByQQ(string qq, IdsAuthConst.ESex sex)
        {
            string url = _appconfig.AuthServer.Authority;
            string loginUrl = url + IdsLoginConst.LOGIN_CONNECT_URL;
            var val = await loginUrl
                .PostUrlEncodedAsync(IdsLoginBuilder.BuilberQQLogin(qq, sex));
            var obj = await val.GetJsonAsync<IdsConnectTokenDto>();
            return obj;
        }
    }
}