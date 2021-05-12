using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 管道输出
    /// </summary>
    public class ProviderOuter : Entity<Guid>
    {
        /// <summary>
        /// 输出的字段名称
        /// </summary>
        public virtual string Name { get; set; }


    }
}
