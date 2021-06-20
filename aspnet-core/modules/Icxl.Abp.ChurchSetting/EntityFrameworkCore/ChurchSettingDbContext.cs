using Icxl.Abp.ChurchSetting.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Icxl.Abp.ChurchSetting.EntityFrameworkCore
{
    [ConnectionStringName("ChurchSetting")]
    public class ChurchSettingDbContext :
        AbpDbContext<ChurchSettingDbContext>,
        IChurchSettingDbContext
    {
        public virtual DbSet<Domain.ChurchSetting> ChurchSettings { get; set; }
        public virtual DbSet<ChurchSettingNode> ChurchSettingNodes { get; set; }

        public ChurchSettingDbContext(
            DbContextOptions<ChurchSettingDbContext> options
        )
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureChurchSetting();
        }
    }
}