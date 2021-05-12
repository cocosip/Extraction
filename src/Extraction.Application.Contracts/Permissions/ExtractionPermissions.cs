using Volo.Abp.Reflection;

namespace Extraction.Permissions
{
    public class ExtractionPermissions
    {
        public const string GroupName = "Extraction";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(ExtractionPermissions));
        }
    }
}