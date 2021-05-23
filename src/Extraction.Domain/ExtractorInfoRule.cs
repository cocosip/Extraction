using System;
using System.Collections.Generic;
using System.Text;
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
     

    }
}
