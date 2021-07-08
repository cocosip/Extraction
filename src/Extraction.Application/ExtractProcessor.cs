using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Extraction
{
    public class ExtractProcessor : IExtractProcessor, ITransientDependency
    {
        protected IGuidGenerator GuidGenerator { get; }
        protected IExtractorInfoRepository ExtractorInfoRepository { get; }
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        public ExtractProcessor(
            IGuidGenerator guidGenerator,
            IExtractorInfoRepository extractorInfoRepository,
            IExtractorProviderRepository extractorProviderRepository)
        {
            GuidGenerator = guidGenerator;
            ExtractorInfoRepository = extractorInfoRepository;
            ExtractorProviderRepository = extractorProviderRepository;
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<Guid> ExtractAsync(ExtractDto input)
        {
            //查询提取器
            var extractorInfo = await ExtractorInfoRepository.FindByNameAsync(input.ExtractorInfoName, true);
            if (extractorInfo == null)
            {
                throw new AbpException($"提取器 '{input.ExtractorInfoName}' 不存在.");
            }
            //提取器管道
            var extractorProvider = await ExtractorProviderRepository.FindByNameAsync(extractorInfo.ProviderName, true);
            if (extractorProvider == null)
            {
                throw new AbpException($"提取器管道 '{extractorInfo.ProviderName}' 不存在.");
            }

            var result = new ExtractResultInfo(
                GuidGenerator.Create(), 
                extractorInfo.ProviderName, 
                extractorInfo.Id, 
                input.HtmlContent,
                Guid.NewGuid().ToString("D"));

            //遍历参数定义
            foreach (var parameterDefination in extractorProvider.Definations)
            {

            }


            return default;
        }
    }
}
