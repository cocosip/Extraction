using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ExtractionSample.Data;
using Volo.Abp.DependencyInjection;

namespace ExtractionSample.EntityFrameworkCore
{
    public class EntityFrameworkCoreExtractionSampleDbSchemaMigrator
        : IExtractionSampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreExtractionSampleDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ExtractionSampleMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ExtractionSampleMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}