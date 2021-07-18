using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Extraction
{
    public class ExtractRecordManager : DomainService, IExtractRecordManager
    {
        protected ExtractionOptions Options { get; }
        protected IParameterCalculator ParameterCalculator { get; }
        protected IExtractResultInfoRepository ExtractResultInfoRepository { get; }
        protected IExtractRecordRepository ExtractRecordRepository { get; }
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        protected IExtractorInfoRepository ExtractorInfoRepository { get; }
        public ExtractRecordManager(
            IOptions<ExtractionOptions> options,
            IParameterCalculator parameterCalculator,
            IExtractResultInfoRepository extractResultInfoRepository,
            IExtractRecordRepository extractRecordRepository,
            IExtractorProviderRepository extractorProviderRepository,
            IExtractorInfoRepository extractorInfoRepository)
        {
            Options = options.Value;
            ParameterCalculator = parameterCalculator;
            ExtractResultInfoRepository = extractResultInfoRepository;
            ExtractRecordRepository = extractRecordRepository;
            ExtractorProviderRepository = extractorProviderRepository;
            ExtractorInfoRepository = extractorInfoRepository;
        }

        /// <summary>
        /// 根据提取结果,生成提取记录
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public virtual async Task<Guid> CreateFromResultAsync(Guid resultId)
        {
            var extractResultInfo = await ExtractResultInfoRepository.GetAsync(resultId, true);
            if (extractResultInfo == null)
            {
                throw new AbpException($"根据提取结果 '{resultId}' 创建记录失败,结果不存在.");
            }

            var extractRecord = new ExtractRecord(
                GuidGenerator.Create(),
                extractResultInfo.ProviderName,
                extractResultInfo.ExtractorInfoId,
                extractResultInfo.HtmlContent,
                Guid.NewGuid().ToString("D"));

            //添加其他记录
            foreach (var item in extractResultInfo.Items)
            {
                var recordItem = new ExtractRecordItem(
                    GuidGenerator.Create(),
                    extractRecord.Id,
                    item.ParameterDefinationId,
                    item.ParameterType, item.Value);

                if (item.Children.Any())
                {
                    foreach (var childItem in item.Children)
                    {
                        var childRecordItem = new ExtractRecordItem(
                            GuidGenerator.Create(),
                            extractRecord.Id,
                            childItem.ParameterDefinationId,
                            childItem.ParameterType,
                            childItem.Value,
                            recordItem.Id);
                        recordItem.AddChild(childRecordItem);
                    }
                }
                extractRecord.AddItem(recordItem);
            }

            //索引
            //查询提取器管道
            var extractorProvider = await ExtractorProviderRepository.FindByNameAsync(extractResultInfo.ProviderName, true);
            foreach (var parameterDefination in extractorProvider.Definations)
            {
                if (parameterDefination.ParameterUseStyle == (int)ParameterUseStyle.All)
                {
                    var currentItem = extractRecord.Items.FirstOrDefault(x => x.ParameterDefinationId == parameterDefination.Id);
                    if (currentItem != null)
                    {
                        var hash = ParameterCalculator.CalculateHash(currentItem.Value);
                        var recordIndex = new ExtractRecordIndex(
                            GuidGenerator.Create(),
                            currentItem.ExtractRecordId,
                            extractRecord.ProviderName,
                            parameterDefination.Name,
                            parameterDefination.ParameterType,
                            hash);

                        extractRecord.AddIndex(recordIndex);
                    }
                }
            }

            await ExtractRecordRepository.InsertAsync(extractRecord);

            return extractRecord.Id;
        }

        /// <summary>
        /// 根据提取结果,检索对应的记录
        /// </summary>
        /// <param name="resultId"></param>
        /// <returns></returns>
        public virtual async Task<Guid?> SearchByResultAsync(Guid resultId)
        {
            var extractResultInfo = await ExtractResultInfoRepository.GetAsync(resultId, true);
            if (extractResultInfo == null)
            {
                throw new AbpException($"根据提取结果 '{resultId}'查询提取器出错,结果不存在.");
            }

            //查询提取器管道
            var extractorProvider = await ExtractorProviderRepository.FindByNameAsync(extractResultInfo.ProviderName, true);
            //foreach (var parameterDefination in extractorProvider.Definations)
            //{
            //    if (parameterDefination.ParameterUseStyle == (int)ParameterUseStyle.All)
            //    {
            //        var currentItem = extractRecord.Items.FirstOrDefault(x => x.ParameterDefinationId == parameterDefination.Id);
            //        if (currentItem != null)
            //        {
            //            var hash = ParameterCalculator.CalculateHash(currentItem.Value);
            //            var recordIndex = new ExtractRecordIndex(
            //                GuidGenerator.Create(),
            //                currentItem.ExtractRecordId,
            //                extractRecord.ProviderName,
            //                parameterDefination.Name,
            //                parameterDefination.ParameterType,
            //                hash);

            //            extractRecord.AddIndex(recordIndex);
            //        }
            //    }
            //}


            return null;
        }
    }
}
