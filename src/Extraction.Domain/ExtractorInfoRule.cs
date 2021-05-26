using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器规则
    /// </summary>
    public class ExtractorInfoRule : Entity<Guid>
    {
        /// <summary>
        /// 提取器的Id
        /// </summary>
        public Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// 根级参数定义Id
        /// </summary>
        public virtual Guid RootDefinationId { get; set; }

        /// <summary>
        /// 当前的参数定义Id
        /// </summary>
        public virtual Guid CurrentDefinationId { get; set; }

        /// <summary>
        /// 提取方式,常量或者是XPath提取
        /// </summary>
        public virtual int ExtractStyle { get; set; }

        /// <summary>
        /// 数据处理方式,1-默认,2-OCR识别
        /// </summary>
        public virtual int HandleStyle { get; set; }

        /// <summary>
        /// 数据类型,1-String(字符串类型),2-Base64图片
        /// </summary>
        public virtual int DataType { get; set; }

        /// <summary>
        /// 规则值
        /// </summary>
        public virtual string RuleValue { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Describe { get; set; }

        public ExtractorInfoRule()
        {

        }

        public ExtractorInfoRule(
            Guid id, 
            Guid extractorInfoId, 
            Guid rootDefinationId, 
            Guid currentDefinationId, 
            int extractStyle,
            int handleStyle,
            int dataType,
            string ruleValue, 
            string describe)
        {
            Id = id;
            ExtractorInfoId = extractorInfoId;
            RootDefinationId = rootDefinationId;
            CurrentDefinationId = currentDefinationId;
            ExtractStyle = extractStyle;
            HandleStyle = handleStyle;
            DataType = dataType;
            RuleValue = ruleValue;
            Describe = describe;
        }

        public void Update(
            Guid extractorInfoId,
            Guid rootDefinationId,
            Guid currentDefinationId,
            int extractStyle,
            int handleStyle,
            int dataType,
            string ruleValue,
            string describe)
        {
            ExtractorInfoId = extractorInfoId;
            RootDefinationId = rootDefinationId;
            CurrentDefinationId = currentDefinationId;
            ExtractStyle = extractStyle;
            HandleStyle = handleStyle;
            DataType = dataType;
            RuleValue = ruleValue;
            Describe = describe;
        }

    }
}
