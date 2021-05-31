using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorProviderDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取器管道名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public List<ExtractorProviderResourceDto> Resources { get; set; }

        /// <summary>
        /// 管道参数定义
        /// </summary>
        public List<ParameterDefinationDto> Definations { get; set; }

        public ExtractorProviderDto()
        {
            Resources = new List<ExtractorProviderResourceDto>();
            Definations = new List<ParameterDefinationDto>();
        }
    }
}
