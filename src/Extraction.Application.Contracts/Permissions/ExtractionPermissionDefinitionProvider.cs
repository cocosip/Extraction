using Extraction.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Extraction.Permissions
{
    public class ExtractionPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(ExtractionPermissions.GroupName, L("Permission:Extraction"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ExtractionResource>(name);
        }
    }
}