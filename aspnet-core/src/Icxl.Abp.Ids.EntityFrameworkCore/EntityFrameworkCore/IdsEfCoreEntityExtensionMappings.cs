using Icxl.Abp.Ids.Users;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Icxl.Abp.Ids.EntityFrameworkCore
{
    public static class IdsEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            IdsGlobalFeatureConfigurator.Configure();
            IdsModuleExtensionConfigurator.Configure();

            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance
                    .MapEfCoreProperty<IdentityUser, string>(
                        nameof(AppUser.QQ),
                        b => { b.HasMaxLength(AppUserConsts.MaxQQLength); }
                    )
                    .MapEfCoreProperty<IdentityUser, int>(
                        nameof(AppUser.Sex),
                        b =>
                        {
                            b.HasMaxLength(AppUserConsts.MaxSexLength);
                            b.HasDefaultValue(1);
                        }
                    );

                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to map these extra properties to table fields in the database.
                 *
                 * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
                 * USE IdsModuleExtensionConfigurator CLASS (in the Domain.Shared project)
                 * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
                 *
                 * Example: Map a property to a table field:

                     ObjectExtensionManager.Instance
                         .MapEfCoreProperty<IdentityUser, string>(
                             "MyProperty",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.HasMaxLength(128);
                             }
                         );

                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */
            });
        }
    }
}