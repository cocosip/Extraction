using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractResultItemDto : CreationAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 提取结果Id
        /// </summary>
        public Guid ExtractResultId { get; set; }

        /// <summary>
        /// 参数Id
        /// </summary>
        public Guid ParameterDefinationId { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public int ParameterType { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public string Value { get; set; }

        public List<ExtractResultItemDto> Children { get; set; }

        public ExtractResultItemDto()
        {
            Children = new List<ExtractResultItemDto>();
        }
    }
}
