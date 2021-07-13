using System;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractRecordIndexDto : CreationAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 提取记录Id
        /// </summary>
        public Guid ExtractRecordId { get; set; }

        /// <summary>
        /// 管道的名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public int ParameterType { get; set; }

        /// <summary>
        /// 参数值Hash
        /// </summary>
        public string ValueHash { get; set; }


    }
}
