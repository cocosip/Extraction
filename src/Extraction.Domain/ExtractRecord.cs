using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Extraction
{
    /// <summary>
    /// 提取记录
    /// </summary>
    public class ExtractRecord : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 管道的名称
        /// </summary>
        public virtual string ProviderName { get; set; }

        /// <summary>
        /// 提取器的Id
        /// </summary>
        public virtual Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// Html数据
        /// </summary>
        public virtual string HtmlContent { get; set; }

        /// <summary>
        /// 记录号
        /// </summary>
        public virtual string RecordNo { get; set; }

        public virtual ICollection<ExtractRecordItem> Items { get; protected set; }

        public virtual ICollection<ExtractRecordIndex> Indexs { get; protected set; }

        public ExtractRecord()
        {
            Items = new List<ExtractRecordItem>();
            Indexs = new List<ExtractRecordIndex>();
        }

        public ExtractRecord(Guid id, string providerName, Guid extractorInfoId, string htmlContent, string recordNo) : this()
        {
            Id = id;
            ProviderName = providerName;
            ExtractorInfoId = extractorInfoId;
            HtmlContent = htmlContent;
            RecordNo = recordNo;
        }

    }
}
