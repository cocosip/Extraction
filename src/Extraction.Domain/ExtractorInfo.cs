using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器信息
    /// </summary>
    public class ExtractorInfo : AggregateRoot<Guid>
    {
        /// <summary>
        /// 提取器管道名
        /// </summary>
        public virtual string ProviderName { get; set; }

        /// <summary>
        /// 提取器的名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 提取器对应的Url地址
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public virtual ICollection<ExtractorInfoResource> Resources { get; protected set; }

        public ExtractorInfo()
        {
            Resources = new List<ExtractorInfoResource>();
        }


    }
}
