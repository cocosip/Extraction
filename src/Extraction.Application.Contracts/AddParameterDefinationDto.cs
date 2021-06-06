using System;

namespace Extraction
{
    public class AddParameterDefinationDto
    {
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


    }
}
