using System;
using System.Text.RegularExpressions;

namespace Extraction
{
    public static class ExtractionUtil
    {
        public static bool IsProviderName(string providerName)
        {
            if (!providerName.IsNullOrWhiteSpace())
            {
                return Regex.IsMatch(providerName, "^[A-Za-z0-9_]{3,}$");
            }
            return false;
        }

    }
}
