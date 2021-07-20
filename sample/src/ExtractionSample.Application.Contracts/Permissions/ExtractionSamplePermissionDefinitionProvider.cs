using ExtractionSample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ExtractionSample.Permissions
{
    public class ExtractionSamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ExtractionSamplePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ExtractionSamplePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ExtractionSampleResource>(name);
        }
    }
}
