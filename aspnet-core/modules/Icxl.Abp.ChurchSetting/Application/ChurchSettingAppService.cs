using System;
using System.Threading.Tasks;
using Icxl.Abp.ChurchSetting.Application.Dtos;
using Icxl.Abp.ChurchSetting.ChurchSettings.Definitions;
using Icxl.Abp.ChurchSetting.ChurchSettings.Providers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Icxl.Abp.ChurchSetting.Application
{
    public class GetForEditOutputDto<T>
    {
        public GetForEditOutputDto(T company, JToken schema)
        {
            data = company;
            Schema = schema;
        }

        public T data { get; set; }

        /// <summary>
        /// <see cref="JToken"/>
        /// </summary>
        public object Schema { get; set; }
    }

    public interface IChurchSettingAppService : ICrudAppService<ChurchSettingDto,
        Guid,
        PagedResultRequestDto,
        ChurchSettingCreateOrEditDto>
    {
        Task<GetForEditOutputDto<ChurchSettingCreateOrEditDto>> GetForEdit(Guid id);


        Task<GetForEditOutputDto<ChurchSettingCreateOrEditDto>> GetByProvider(GetChurchSettingDto input);
    }

    public class ChurchSettingAppService :
        CrudAppService<
            Domain.ChurchSetting,
            ChurchSettingDto,
            Guid,
            PagedResultRequestDto,
            ChurchSettingCreateOrEditDto>
        , IChurchSettingAppService
    {
        private readonly IChurchSettingDefinitionManager _churchSettingDefinitionManager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IChurchSettingProvider _churchSettingProvider;

        public ChurchSettingAppService(
            IRepository<Domain.ChurchSetting, Guid> repository,
            IChurchSettingDefinitionManager ChurchSettingDefinitionManager,
            IGuidGenerator guidGenerator, IChurchSettingProvider ChurchSettingProvider) : base(repository)
        {
            _churchSettingDefinitionManager = ChurchSettingDefinitionManager;
            _guidGenerator = guidGenerator;
            _churchSettingProvider = ChurchSettingProvider;
        }

        public async Task<GetForEditOutputDto<ChurchSettingCreateOrEditDto>> GetForEdit(Guid id)
        {
            var find = await Repository
                .Include(x => x.ChurchSettingNodes)
                .FirstOrDefaultAsync(z => z.Id == id);

            var schema = JToken.FromObject(new { });

            var audits = _churchSettingDefinitionManager.GetAll();
            schema["audits"] = audits.GetSelection("string", "name", @"{0}", new[] {"Name"}, "Name");

            return new GetForEditOutputDto<ChurchSettingCreateOrEditDto>(
                ObjectMapper.Map<Domain.ChurchSetting, ChurchSettingCreateOrEditDto>(find), schema);
        }

        public async Task<GetForEditOutputDto<ChurchSettingCreateOrEditDto>> GetByProvider(GetChurchSettingDto input)
        {
            var dto = await _churchSettingProvider.GetOrNullAsync(input.DefinitionName, input.ChurchSettingName);
            if (dto.HasValue)
            {
                return await GetForEdit(dto.Value);
            }
            else
            {
                return null;
            }
        }


        public override async Task<ChurchSettingDto> CreateAsync(ChurchSettingCreateOrEditDto input)
        {
            await CheckCreatePolicyAsync();

            if (input.ChurchSettingNodes != null)
            {
                foreach (var node in input.ChurchSettingNodes)
                {
                    if (node.Id == new Guid())
                    {
                        node.Id = _guidGenerator.Create();
                    }
                }
            }


            var entity = await MapToEntityAsync(input);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }


        public override async Task<ChurchSettingDto> UpdateAsync(Guid id, ChurchSettingCreateOrEditDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await Repository.Include(x => x.ChurchSettingNodes).FirstOrDefaultAsync(x => x.Id == id);

            foreach (var node in input.ChurchSettingNodes)
            {
                if (node.Id == new Guid())
                {
                    node.Id = _guidGenerator.Create();
                }
            }

            MapToEntity(input, entity);

            await Repository.UpdateAsync(entity, autoSave: true);

            return MapToGetOutputDto(entity);
        }
    }
}