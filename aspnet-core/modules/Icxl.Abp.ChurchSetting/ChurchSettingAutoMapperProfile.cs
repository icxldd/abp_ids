using System.Linq;
using AutoMapper;
using Icxl.Abp.ChurchSetting.Application.Dtos;
using Icxl.Abp.ChurchSetting.Domain;

namespace Icxl.Abp.ChurchSetting
{
    public class ChurchSettingAutoMapperProfile : Profile
    {
        public ChurchSettingAutoMapperProfile()
        {
            CreateMap<Domain.ChurchSetting, ChurchSettingDto>();
            CreateMap<ChurchSettingCreateOrEditDto, Domain.ChurchSetting>()
                .ForMember(x => x.NodesMaxIndex,
                    opt => opt.MapFrom(x => x.ChurchSettingNodes.Count))
                .ReverseMap();
            CreateMap<ChurchSettingNode, ChurchSettingNodeDto>();
            CreateMap<ChurchSettingNodeCreateOrEditDto, ChurchSettingNode>()
                .ReverseMap();
        }
    }
}