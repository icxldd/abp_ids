using AutoMapper;
using Icxl.Abp.Ids.Authorize;
using Icxl.Abp.Ids.Users;

namespace Icxl.Abp.Ids
{
    public class IdsApplicationAutoMapperProfile : Profile
    {
        public IdsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<AppUser, AppUserDto>();
        }
    }
}
