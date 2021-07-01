using System.Threading.Tasks;

namespace Icxl.Abp.Ids.Authorize
{
    public interface IOAuthShowService
    {
        Task<AppUserDto> ShowCurrentAccount();
    }
}