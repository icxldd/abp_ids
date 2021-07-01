using System.Threading.Tasks;

namespace Icxl.Abp.Ids.Authorize
{
    public interface IQQOAuthSerivce
    {
        Task<IdsConnectTokenDto> LoginByQQ(string qq, IdsAuthConst.ESex sex);
    }
}