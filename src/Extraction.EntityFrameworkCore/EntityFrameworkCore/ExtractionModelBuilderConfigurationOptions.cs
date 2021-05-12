using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Extraction.EntityFrameworkCore
{
    public class ExtractionModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public ExtractionModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}