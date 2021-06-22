using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ParameterDefinationDto : EntityDto<Guid>
    {
        public Guid ExtractorProviderId { get; set; }

        /// <summary>
        /// 上级参数的Id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public int ParameterType { get; set; }

        /// <summary>
        /// 参数使用方式
        /// </summary>
        public int ParameterUseStyle { get; set; }

        /// <summary>
        /// 下级参数
        /// </summary>
        public List<ParameterDefinationDto> Childrens { get; set; }

        public ParameterDefinationDto()
        {
            Childrens = new List<ParameterDefinationDto>();
        }
    }
}
