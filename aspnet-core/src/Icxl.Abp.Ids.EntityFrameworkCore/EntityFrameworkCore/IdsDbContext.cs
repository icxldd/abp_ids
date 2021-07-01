using Icxl.Abp.ChurchSetting.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Icxl.Abp.Ids.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See IdsMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class IdsDbContext : AbpDbContext<IdsDbContext>
    {
        public DbSet<AppUser> Users { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside IdsDbContextModelCreatingExtensions.ConfigureIds
         */

        public IdsDbContext(DbContextOptions<IdsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                b.Property(x => x.QQ).IsRequired(false).HasMaxLength(AppUserConsts.MaxQQLength).HasColumnName(nameof(AppUser.QQ));
                b.Property(x => x.Sex).HasDefaultValue(1).IsRequired().HasMaxLength(AppUserConsts.MaxQQLength).HasColumnName(nameof(AppUser.Sex));
                /* Configure mappings for your additional properties
                 * Also see the IdsEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigureIds method */

            builder.ConfigureIds();
        }
    }
}
