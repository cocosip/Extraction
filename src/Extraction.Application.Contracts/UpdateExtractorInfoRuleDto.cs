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
        /// 根级参数定义Id
        /// </summary>
        [Required]
        public Guid RootDefinationId { get; set; }

        /// <summary>
        /// 当前的参数定义Id
        /// </summary>
        [Required]
        public Guid CurrentDefinationId { get; set; }

        /// <summary>
        /// 提取方式,常量或者是XPath提取
        /// </summary>
        [Required]
        public int ExtractStyle { get; set; }

        /// <summary>
        /// 数据处理方式,1-默认,2-OCR识别
        /// </summary>
        [Required]
        public int HandleStyle { get; set; }

        /// <summary>
        /// 数据类型,1-String(字符串类型),2-Base64图片
        /// </summary>
        [Required]
        public int DataType { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxRuleValueLength))]
        public string RuleValue { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoRuleConsts), nameof(ExtractorInfoRuleConsts.MaxDescribeLength))]
        public string Describe { get; set; }
    }
}
