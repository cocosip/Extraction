using System;
using Volo.Abp.Application.Dtos;

namespace Extraction
{
    public class ExtractorProviderResourceDto : EntityDto<Guid>
    {
        /// <summary>
        /// 提取器管道Id
        /// </summary>
        public Guid ExtractorProviderId { get; set; }

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
        /// Url访问地址
        /// </summary>
        public string Url { get; set; }
    }
}
