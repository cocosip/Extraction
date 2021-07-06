using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    /// <summary>
    /// 修改提取器规则
    /// </summary>
    public class UpdateExtractorInfoRuleDto
    {
        /// <summary>
        /// 参数定义Id
        /// </summary>
        [Required]
        public Guid ParameterDefinationId { get; set; }

        /// <summary>
        /// XPath SelectNodeType
        /// </summary>
        [Required]
        public int SelectNodeType { get; set; }

        /// <summary>
        /// XPath 提取到的Node的处理
        /// </summary>
        [Required]
        public int NodeManipulationType { get; set; }

        /// <summary>
        /// OCR的特定处理设置
        /// </summary>
        [Required]
        public int HandleStyle { get; set; }

        /// <summary>
        /// XPath提取的值
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxXPathValueLength))]
        public string XPathValue { get; set; }

        /// <summary>
        /// 在提取值之前的预处理
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxPreHandlersLength))]
        public string PreHandlers { get; set; }

        /// <summary>
        /// 在提取到值之后的处理
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxAfterHandlersLength))]
        public string AfterHandlers { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxDescribeLength))]
        public string Describe { get; set; }
    }
}
