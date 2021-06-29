using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Extraction
{
    /// <summary>
    /// 提取记录索引
    /// </summary>
    public class ExtractRecordIndex : CreationAuditedEntity<Guid>
    {
        /// <summary>
        /// 提取记录Id
        /// </summary>
        public virtual Guid ExtractRecordId { get; set; }

        /// <summary>
        /// 管道的名称
        /// </summary>
        public virtual string ProviderName { get; set; }

        /// <summary>
        /// 参数名
        /// </summary>
        public virtual string ParameterName { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public virtual int ParameterType { get; set; }

        /// <summary>
        /// 参数值Hash
        /// </summary>
        public virtual string ValueHash { get; set; }
    
    }
}
