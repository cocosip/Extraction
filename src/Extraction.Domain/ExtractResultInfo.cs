using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace Extraction
{
    /// <summary>
    /// 提取结果信息(临时,可清除)
    /// </summary>
    public class ExtractResultInfo : AuditedAggregateRoot<Guid>
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
        /// 结果编号
        /// </summary>
        public virtual string ResultNo { get; set; }

        public virtual ICollection<ExtractResultItem> Items { get; protected set; }

        public ExtractResultInfo()
        {
            Items = new List<ExtractResultItem>();
        }

        public ExtractResultInfo(
            Guid id,
            string providerName,
            Guid extractorInfoId,
            string htmlContent,
            string resultNo) : this()
        {
            Id = id;
            ProviderName = providerName;
            ExtractorInfoId = extractorInfoId;
            HtmlContent = htmlContent;
            ResultNo = resultNo;
        }


        public void AddItem(ExtractResultItem item)
        {
            var queryItem = Items.FirstOrDefault(x => x.Id == item.Id);
            if (queryItem == null)
            {
                Items.Add(item);
            }
        }
    }
}
