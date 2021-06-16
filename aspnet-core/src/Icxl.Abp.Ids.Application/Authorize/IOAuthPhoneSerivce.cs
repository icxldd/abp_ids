using System.Threading.Tasks;

namespace Icxl.Abp.Ids.Authorize
{
    
    public interface IOAuthPhoneSerivce
    {
        /// <summary>
        /// 手机号验证码登陆 
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        Task<IdsConnectTokenDto> LoginByPhoneNumber(string phone,string verifyCode);
    }
}