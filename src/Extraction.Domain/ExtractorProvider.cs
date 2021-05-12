using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器管道
    /// </summary>
    public class ExtractorProvider : AggregateRoot<Guid>
    {
        /// <summary>
        /// 提取器管道名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public virtual ICollection<ProviderResource> Resources { get; set; }


        public ExtractorProvider()
        {
            Resources = new List<ProviderResource>();
        }



    }
}
