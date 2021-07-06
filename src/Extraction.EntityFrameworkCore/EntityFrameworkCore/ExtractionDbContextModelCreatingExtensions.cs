using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Extraction.EntityFrameworkCore
{
    public static class ExtractionDbContextModelCreatingExtensions
    {
        public static void ConfigureExtraction(
            this ModelBuilder builder,
            Action<ExtractionModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new ExtractionModelBuilderConfigurationOptions(
                ExtractionDbProperties.DbTablePrefix,
                ExtractionDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */

            //提取器管道
            builder.Entity<ExtractorProvider>(b =>
            {
                b.ToTable(options.TablePrefix + "ExtractorProviders", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.Name).IsRequired().HasMaxLength(ExtractorProviderConsts.MaxNameLength);
                b.Property(p => p.Title).IsRequired().HasMaxLength(ExtractorProviderConsts.MaxTitleLength);
                b.Property(p => p.Describe).HasMaxLength(ExtractorProviderConsts.MaxDescribeLength);

                b.HasIndex(p => p.Name);
                b.HasMany(p => p.Resources).WithOne().HasForeignKey(p => p.ExtractorProviderId).IsRequired();
                b.HasMany(p => p.Definations).WithOne().HasForeignKey(p => p.ExtractorProviderId).IsRequired();
            });

            //提取器管道资源
            builder.Entity<ExtractorProviderResource>(b =>
            {
                b.ToTable(options.TablePrefix + "ExtractorProviderResources", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.ExtractorProviderId).IsRequired();
                b.Property(p => p.Container).IsRequired().HasMaxLength(ExtractorProviderResourceConsts.MaxContainerLength);
                b.Property(p => p.FileId).IsRequired().HasMaxLength(ExtractorProviderResourceConsts.MaxFileIdLength);
                b.Property(p => p.FileType).IsRequired();
            });

            //参数定义
            builder.Entity<ParameterDefination>(b =>
            {
                b.ToTable(options.TablePrefix + "ParameterDefinations", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.ExtractorProviderId).IsRequired();
                b.Property(p => p.ParentId).IsRequired(false);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ParameterDefinationConsts.MaxNameLength);
                b.Property(p => p.ParameterType).IsRequired();

                b.HasMany(p => p.Children).WithOne().HasForeignKey(p => p.ParentId);
                b.HasIndex(p => p.Name);
            });

            //管道提取器
            builder.Entity<ExtractorInfo>(b =>
            {
                b.ToTable(options.TablePrefix + "ExtractorInfos", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.ProviderName).IsRequired().HasMaxLength(ExtractorInfoConsts.MaxProviderNameLength);
                b.Property(p => p.Name).IsRequired().HasMaxLength(ExtractorInfoConsts.MaxNameLength);
                b.Property(p => p.Match).IsRequired().HasMaxLength(ExtractorInfoConsts.MaxMatchLength);
                b.Property(p => p.Domain).IsRequired().HasMaxLength(ExtractorInfoConsts.MaxDomainLength);
                b.Property(p => p.Url).IsRequired().HasMaxLength(ExtractorInfoConsts.MaxUrlLength);
                b.Property(p => p.Describe).HasMaxLength(ExtractorInfoConsts.MaxDescribeLength);

                b.HasMany(p => p.Resources).WithOne().HasForeignKey(p => p.ExtractorInfoId);
                b.HasMany(p => p.Rules).WithOne().HasForeignKey(p => p.ExtractorInfoId);
                b.HasIndex(p => p.Name);
            });

            //提取器资源
            builder.Entity<ExtractorInfoResource>(b =>
            {
                b.ToTable(options.TablePrefix + "ExtractorInfoResources", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.ExtractorInfoId).IsRequired();
                b.Property(p => p.Container).IsRequired().HasMaxLength(ExtractorInfoResourceConsts.MaxContainerLength);
                b.Property(p => p.FileId).IsRequired().HasMaxLength(ExtractorInfoResourceConsts.MaxFileIdLength);
                b.Property(p => p.FileType).IsRequired();
            });

            //提取器规则
            builder.Entity<ExtractorInfoRule>(b =>
            {
                b.ToTable(options.TablePrefix + "ExtractorInfoRules", options.Schema);
                b.ConfigureByConvention();

                b.Property(p => p.ExtractorInfoId).IsRequired();
                b.Property(p => p.ParameterDefinationId).IsRequired();
                b.Property(p => p.SelectNodeType).IsRequired();
                b.Property(p => p.NodeManipulationType).IsRequired();
                b.Property(p => p.HandleStyle).IsRequired();
                b.Property(p => p.XPathValue).IsRequired().HasMaxLength(ExtractorInfoRuleConsts.MaxXPathValueLength);
                b.Property(p => p.PreHandlers).HasMaxLength(ExtractorInfoRuleConsts.MaxPreHandlersLength);
                b.Property(p => p.PreHandlers).HasMaxLength(ExtractorInfoRuleConsts.MaxAfterHandlersLength);
                b.Property(p => p.Describe).HasMaxLength(ExtractorInfoRuleConsts.MaxDescribeLength);
            });

        }
    }
}