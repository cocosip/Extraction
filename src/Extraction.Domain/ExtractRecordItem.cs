using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取记录项
    /// </summary>
    public class ExtractRecordItem : Entity<Guid>
    {
        /// <summary>
        /// 提取结果Id
        /// </summary>
        public virtual Guid ExtractRecordId { get; set; }

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

        /// <summary>
        /// 上级参数
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        public virtual ICollection<ExtractRecordItem> Children { get; protected set; }

        public ExtractRecordItem()
        {
            Children = new List<ExtractRecordItem>();
        }

        public ExtractRecordItem(
            Guid id,
            Guid extractRecordId,
            Guid parameterDefinationId,
            int parameterType,
            string value,
            Guid? parentId = null) : this()
        {
            Id = id;
            ExtractRecordId = extractRecordId;
            ParameterDefinationId = parameterDefinationId;
            ParameterType = parameterType;
            Value = value;
            ParentId = parentId;
        }


        public void AddChild(ExtractRecordItem childItem)
        {
            Children.Add(childItem);
        }
    }
}
