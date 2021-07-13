using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取结果项
    /// </summary>
    public class ExtractResultItem : Entity<Guid>
    {
        /// <summary>
        /// 提取结果Id
        /// </summary>
        public virtual Guid ExtractResultId { get; set; }

        /// <summary>
        /// 参数Id
        /// </summary>
        public virtual Guid ParameterDefinationId { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public virtual int ParameterType { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public virtual string Value { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual ICollection<ExtractResultItem> Children { get; protected set; }

        public ExtractResultItem()
        {
            Children = new List<ExtractResultItem>();
        }

        public ExtractResultItem(
            Guid id,
            Guid extractResultId,
            Guid parameterDefinationId,
            int parameterType,
            string value,
            Guid? parentId = null) : this()
        {
            Id = id;
            ExtractResultId = extractResultId;
            ParameterDefinationId = parameterDefinationId;
            ParameterType = parameterType;
            Value = value;
            ParentId = parentId;
        }

        public void AddChild(ExtractResultItem childItem)
        {
            Children.Add(childItem);
        }


    }
}
