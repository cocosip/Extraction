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
        /// 参数定义Id
        /// </summary>
        public virtual Guid ParameterDefinationId { get; set; }

        /// <summary>
        /// XPath SelectNodeType
        /// </summary>
        public virtual int SelectNodeType { get; set; }

        /// <summary>
        /// XPath 提取到的Node的处理
        /// </summary>
        public virtual int NodeManipulationType { get; set; }

        /// <summary>
        /// OCR的特定处理设置
        /// </summary>
        public virtual int HandleStyle { get; set; }

        /// <summary>
        /// XPath提取的值
        /// </summary>
        public virtual string XPathValue { get; set; }

        /// <summary>
        /// 在提取值之前的预处理
        /// </summary>
        public virtual string PreHandlers { get; set; }

        /// <summary>
        /// 在提取到值之后的处理
        /// </summary>
        public virtual string AfterHandlers { get; set; }

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
            Guid parameterDefinationId,
            int selectNodeType,
            int nodeManipulationType,
            int handleStyle,
            string xPathValue,
            string preHandlers,
            string afterHandlers,
            string describe)
        {
            Id = id;
            ExtractorInfoId = extractorInfoId;
            ParameterDefinationId = parameterDefinationId;
            SelectNodeType = selectNodeType;
            NodeManipulationType = nodeManipulationType;
            HandleStyle = handleStyle;
            XPathValue = xPathValue;
            PreHandlers = preHandlers;
            AfterHandlers = afterHandlers;
            Describe = describe;
        }

        public void Update(
            Guid parameterDefinationId,
            int selectNodeType,
            int nodeManipulationType,
            int handleStyle,
            string xPathValue,
            string preHandlers,
            string afterHandlers,
            string describe)
        {
            ParameterDefinationId = parameterDefinationId;
            SelectNodeType = selectNodeType;
            NodeManipulationType = nodeManipulationType;
            HandleStyle = handleStyle;
            XPathValue = xPathValue;
            PreHandlers = preHandlers;
            AfterHandlers = afterHandlers;
            Describe = describe;
        }
    }
}
