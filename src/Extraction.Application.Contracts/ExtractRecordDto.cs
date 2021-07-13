using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractRecordDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 管道的名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 提取器的Id
        /// </summary>
        public Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// Html数据
        /// </summary>
        public string HtmlContent { get; set; }

        /// <summary>
        /// 记录号
        /// </summary>
        public string RecordNo { get; set; }

        public List<ExtractRecordItemDto> Items { get; set; }

        public List<ExtractRecordIndexDto> Indexs { get; set; }

        public ExtractRecordDto()
        {
            Items = new List<ExtractRecordItemDto>();
            Indexs = new List<ExtractRecordIndexDto>();
        }
    }
}
