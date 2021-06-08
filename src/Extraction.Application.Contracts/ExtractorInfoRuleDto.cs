using System;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorInfoRuleDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取器的Id
        /// </summary>
        public Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// 根级参数定义Id
        /// </summary>
        public Guid RootDefinationId { get; set; }

        /// <summary>
        /// 当前的参数定义Id
        /// </summary>
        public Guid CurrentDefinationId { get; set; }

        /// <summary>
        /// 提取方式,常量或者是XPath提取
        /// </summary>
        public int ExtractStyle { get; set; }

        /// <summary>
        /// 数据处理方式,1-默认,2-OCR识别
        /// </summary>
        public int HandleStyle { get; set; }

        /// <summary>
        /// 数据类型,1-String(字符串类型),2-Base64图片
        /// </summary>
        public int DataType { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        public string RuleValue { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
    }
}
