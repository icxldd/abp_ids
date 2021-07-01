using System.Threading.Tasks;

namespace Icxl.Abp.Ids.Authorize
{
    public interface IQQOAuthSerivce
    {
        Task<QQLoginDto> LoginByQQ(string qq, IdsAuthConst.ESex sex);
    }
}