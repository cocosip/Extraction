using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractResultInfoDto : AuditedEntityDto<Guid>
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
        /// 结果编号
        /// </summary>
        public string ResultNo { get; set; }

        public List<ExtractResultItemDto> Items { get; set; }

        public ExtractResultInfoDto()
        {
            Items = new List<ExtractResultItemDto>();
        }
    }
}
