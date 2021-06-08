using System;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorInfoResourceDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取器的Id
        /// </summary>
        public Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// 文件存储Container名称
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// 文件存储的Id
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int FileType { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 访问地址
        /// </summary>
        public string Url { get; set; }
    }
}
