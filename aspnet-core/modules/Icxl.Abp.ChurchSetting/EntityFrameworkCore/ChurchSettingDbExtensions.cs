using Icxl.Abp.ChurchSetting.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Icxl.Abp.ChurchSetting.EntityFrameworkCore
{
    public static class ChurchSettingDbExtensions
    {
        public static void ConfigureChurchSetting(this ModelBuilder builder)
        {
            builder.Entity<Domain.ChurchSetting>(b =>
            {
                b.ToTable(ChurchSettingConsts.DbTablePrefix + "ChurchSetting", ChurchSettingConsts.DbSchema);
                b.ConfigureFullAuditedAggregateRoot();

                b.Property(x => x.ChurchSettingName).IsRequired().HasMaxLength(ChurchSettingConsts.MaxNameLength);
                b.Property(x => x.ProviderName).IsRequired().HasMaxLength(ChurchSettingConsts.ProviderNameLength);
                b.Property(x => x.ChurchSettingName).HasMaxLength(ChurchSettingConsts.ProviderKeyLength);

                b.HasMany(x => x.ChurchSettingNodes).WithOne(x => x.ChurchSetting);
            });

            builder.Entity<ChurchSettingNode>(b =>
            {
                b.ToTable(ChurchSettingConsts.DbTablePrefix + "ChurchSettingNode", ChurchSettingConsts.DbSchema);
                b.ConfigureCreationAudited();

                b.Property(x => x.Desc).HasMaxLength(ChurchSettingConsts.ShortDescLenght);

                // Many-To-One
                b.HasOne(x => x.ChurchSetting).WithMany(x => x.ChurchSettingNodes).HasForeignKey(qt => qt.ChurchSettingId);
            });
        }
    }
}