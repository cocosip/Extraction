using HtmlAgilityPack;
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
        protected IOcrService OcrService { get; }
        protected IExtractorInfoRepository ExtractorInfoRepository { get; }
        protected IExtractorProviderRepository ExtractorProviderRepository { get; }
        protected IExtractResultInfoRepository ExtractResultInfoRepository { get; }
        public ExtractProcessor(
            IGuidGenerator guidGenerator,
            IOcrService ocrService,
            IExtractorInfoRepository extractorInfoRepository,
            IExtractorProviderRepository extractorProviderRepository,
            IExtractResultInfoRepository extractResultInfoRepository)
        {
            GuidGenerator = guidGenerator;
            OcrService = ocrService;
            ExtractorInfoRepository = extractorInfoRepository;
            ExtractorProviderRepository = extractorProviderRepository;
            ExtractResultInfoRepository = extractResultInfoRepository;
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

            //加载html
            var doc = new HtmlDocument();
            doc.LoadHtml(input.HtmlContent);

            //遍历参数定义
            foreach (var parameterDefination in extractorProvider.Definations)
            {
                //简单提取器,直接提取内容
                if (parameterDefination.ParameterType == (int)ProviderParameterType.Simple)
                {
                    var value = "";
                    //获取当前的规则
                    var rule = extractorInfo.Rules.FirstOrDefault(x => x.ParameterDefinationId == parameterDefination.Id);
                    if (rule != null)
                    {
                        //OCR识别只在简单参数中使用
                        if (rule.HandleStyle == (int)HandleStyle.Ocr)
                        {
                            //OCR 识别
                            var node = doc.DocumentNode.SelectSingleNode(rule.XPathValue);
                            var base64 = GetNodeValue(node, rule.NodeManipulationType);
                            value = OcrService.Recognize(base64);
                        }
                        else
                        {
                            var node = doc.DocumentNode.SelectSingleNode(rule.XPathValue);
                            value = GetNodeValue(node, rule.NodeManipulationType);
                        }
                        value = AfterHandle(value, rule.AfterHandlers);
                    }
                    result.Items.Add(new ExtractResultItem(
                        GuidGenerator.Create(),
                        rule.Id,
                        parameterDefination.Id,
                        parameterDefination.ParameterType,
                        value));
                }

                //List类型
                if (parameterDefination.ParameterType == (int)ProviderParameterType.List)
                {
                    //获取当前的规则
                    var rule = extractorInfo.Rules.FirstOrDefault(x => x.ParameterDefinationId == parameterDefination.Id);
                    //List的Item
                    var item = new ExtractResultItem(
                        GuidGenerator.Create(),
                        rule.Id,
                        parameterDefination.Id,
                        parameterDefination.ParameterType,
                        "",
                        null);

                    result.Items.Add(item);

                    if (rule != null)
                    {
                        //子规则
                        var childParameterDefinations = parameterDefination.Children.ToList();

                        //子节点
                        var childNodes = doc.DocumentNode.SelectNodes(rule.XPathValue);
                        foreach (var childNode in childNodes)
                        {
                            //子参数(子参数OCR不可用)
                            foreach (var childParameterDefination in childParameterDefinations)
                            {
                                var childRule = extractorInfo.Rules.FirstOrDefault(x => x.ParameterDefinationId == childParameterDefination.Id);
                                if (childRule != null)
                                {
                                    var childValue = GetNodeValue(childNode, rule.NodeManipulationType);
                                    childValue = AfterHandle(childValue, rule.AfterHandlers);
                                    item.Children.Add(new ExtractResultItem(
                                        GuidGenerator.Create(),
                                        childRule.Id,
                                        childParameterDefination.Id,
                                        parameterDefination.ParameterType,
                                        childValue,
                                        item.Id));
                                }
                            }
                        }
                    }
                }
            }

            await ExtractResultInfoRepository.InsertAsync(result);
            return result.Id;
        }

        /// <summary>
        /// 数据后处理
        /// </summary>
        private string AfterHandle(string value, string afterHandlers)
        {
            return value;
        }

        private string GetNodeValue(HtmlNode htmlNode, int nodeManipulationType)
        {
            return nodeManipulationType switch
            {
                (int)NodeManipulationType.InnerHtml => htmlNode.InnerText,
                (int)NodeManipulationType.InnerText => htmlNode.InnerText,
                (int)NodeManipulationType.OuterHtml => htmlNode.OuterHtml,
                _ => htmlNode.GetDirectInnerText(),
            };
        }

    }
}
