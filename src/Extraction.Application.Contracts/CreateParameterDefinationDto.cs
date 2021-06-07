using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    public class CreateParameterDefinationDto
    {
        /// <summary>
        /// 上级参数的Id
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ParameterDefinationConsts), nameof(ParameterDefinationConsts.MaxNameLength))]
        public string Name { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        [Required]
        public int ParameterType { get; set; }

    }
}
