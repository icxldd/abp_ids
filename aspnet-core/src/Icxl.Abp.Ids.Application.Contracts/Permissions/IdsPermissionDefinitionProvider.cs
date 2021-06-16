using Icxl.Abp.Ids.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Icxl.Abp.Ids.Permissions
{
    public class IdsPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(IdsPermissions.GroupName, L("Ids"));

            //Define your own permissions here. Example:
            myGroup.AddPermission(IdsPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<IdsResource>(name);
        }
    }
}
