using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ExtractionSample.EntityFrameworkCore
{
    public static class ExtractionSampleDbContextModelCreatingExtensions
    {
        public static void ConfigureExtractionSample(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ExtractionSampleConsts.DbTablePrefix + "YourEntities", ExtractionSampleConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}