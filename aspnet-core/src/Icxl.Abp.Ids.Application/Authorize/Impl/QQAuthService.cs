using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Flurl.Http;
using Icxl.Abp.Ids.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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


        public async Task<QQLoginDto> LoginByQQ(string qq, IdsAuthConst.ESex sex)
        {
            string headImage, nickName;

            headImage = IdsQQApiConst.HeadImageUrl(qq);
            // string str = await IdsQQApiConst.QQInfoUrl(qq).GetStringAsync();
            string str = IdsQQApiConst.getString(IdsQQApiConst.QQInfoUrl(qq));
            var qq_obj = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(IdsQQApiConst.parseQQJson(str));
            var qq_arrar = qq_obj[qq];
            nickName = qq_arrar[^2].ToString();

            string url = _appconfig.AuthServer.Authority;
            string loginUrl = url + IdsLoginConst.LOGIN_CONNECT_URL;
            var val = await loginUrl
                .PostUrlEncodedAsync(IdsLoginBuilder.BuilberQQLogin(qq, sex, nickName));
            var obj = await val.GetJsonAsync<IdsConnectTokenDto>();

            if (!obj.access_token.IsNullOrWhiteSpace())
            {
                return await Task.FromResult(new QQLoginDto()
                {
                    tokenDto = obj,
                    headImageUrl = headImage,
                    name = nickName,
                    sex = (int) sex
                });
            }
            else
            {
                throw new AuthenticationException("登陆失败");
            }
        }
    }
}