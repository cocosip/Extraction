using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Extraction.MongoDB
{
    public class ExtractionMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public ExtractionMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}