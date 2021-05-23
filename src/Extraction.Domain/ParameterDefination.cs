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
        /// 下级参数
        /// </summary>
        public virtual ICollection<ParameterDefination> Childrens { get; protected set; }

        public ParameterDefination()
        {
            Childrens = new List<ParameterDefination>();
        }
    }
}
