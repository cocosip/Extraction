using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractRecordItemDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取结果Id
        /// </summary>
        public Guid ExtractRecordId { get; set; }

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

        public Guid? ParentId { get; set; }

        public List<ExtractRecordItemDto> Children { get; set; }

        public ExtractRecordItemDto()
        {
            Children = new List<ExtractRecordItemDto>();
        }
    }
}
