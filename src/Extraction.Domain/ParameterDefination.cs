using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 参数定义
    /// </summary>
    public class ParameterDefination : Entity<Guid>
    {
        public virtual Guid ExtractorProviderId { get; set; }

        /// <summary>
        /// 上级参数的Id
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public virtual int ParameterType { get; set; }

        /// <summary>
        /// 使用方式
        /// </summary>
        public virtual int ParameterUseStyle { get; set; }

        /// <summary>
        /// 下级参数
        /// </summary>
        public virtual ICollection<ParameterDefination> Children { get; protected set; }

        public ParameterDefination()
        {
            Children = new List<ParameterDefination>();
        }

        public ParameterDefination(Guid id, Guid extractorProviderId, Guid? parentId, string name, int parameterType, int parameterUseStyle)
        {
            Id = id;
            ExtractorProviderId = extractorProviderId;
            ParentId = parentId;
            Name = name;
            ParameterType = parameterType;
            ParameterUseStyle = parameterUseStyle;
        }

        public void Update(Guid? parentId, string name, int parameterType, int parameterUseStyle)
        {
            ParentId = parentId;
            Name = name;
            ParameterType = parameterType;
            ParameterUseStyle = parameterUseStyle;
        }
    }
}
