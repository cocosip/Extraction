using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorInfoDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取器管道Id
        /// </summary>
        public Guid ExtractorProviderId { get; set; }

        /// <summary>
        /// 提取器的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 匹配的正则表达式
        /// </summary>
        public string Match { get; set; }

        /// <summary>
        /// 域名地址
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 提取器对应的Url地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public List<ExtractorInfoResourceDto> Resources { get; set; }

        /// <summary>
        /// 规则
        /// </summary>
        public List<ExtractorInfoRuleDto> Rules { get; set; }

        public ExtractorInfoDto()
        {
            Resources = new List<ExtractorInfoResourceDto>();
            Rules = new List<ExtractorInfoRuleDto>();
        }
    }
}
