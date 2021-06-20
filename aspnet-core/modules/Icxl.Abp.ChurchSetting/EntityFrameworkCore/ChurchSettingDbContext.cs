using Icxl.Abp.ChurchSetting.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Icxl.Abp.ChurchSetting.EntityFrameworkCore
{
    public class ChurchSettingDbContext :
        AbpDbContext<ChurchSettingDbContext>,
        IChurchSettingDbContext
    {
        public DbSet<Domain.ChurchSetting> ChurchSettings { get; set; }
        public DbSet<ChurchSettingNode> ChurchSettingNodes { get; set; }

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