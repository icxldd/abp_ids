using Icxl.Abp.ChurchSetting.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Icxl.Abp.ChurchSetting.EntityFrameworkCore
{
    [ConnectionStringName("ChurchSetting")]
    public interface IChurchSettingDbContext: IEfCoreDbContext
    {
        public DbSet<Domain.ChurchSetting> ChurchSettings { get; set; }
        public DbSet<ChurchSettingNode> ChurchSettingNodes { get; set; }
    }
}