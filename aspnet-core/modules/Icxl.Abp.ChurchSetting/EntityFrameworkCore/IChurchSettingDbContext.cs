using Icxl.Abp.ChurchSetting.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Icxl.Abp.ChurchSetting.EntityFrameworkCore
{
    [ConnectionStringName("ChurchSetting")]
    public interface IChurchSettingDbContext: IEfCoreDbContext
    {
        DbSet<Domain.ChurchSetting> ChurchSettings { get; set; }
        DbSet<ChurchSettingNode> ChurchSettingNodes { get; set; }
    }
}