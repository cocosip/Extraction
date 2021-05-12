using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Extraction.MongoDB
{
    public static class ExtractionMongoDbContextExtensions
    {
        public static void ConfigureExtraction(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ExtractionMongoModelBuilderConfigurationOptions(
                ExtractionDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}