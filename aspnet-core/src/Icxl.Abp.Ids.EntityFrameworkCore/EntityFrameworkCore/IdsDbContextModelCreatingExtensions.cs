using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    public static class IdsDbContextModelCreatingExtensions
    {
        public static void ConfigureIds(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(IdsConsts.DbTablePrefix + "YourEntities", IdsConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}