using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器的资源文件(每个提取器都有多个资源文件)
    /// </summary>
    public class ExtractorInfoResource : Entity<Guid>
    {
        /// <summary>
        /// 提取器的Id
        /// </summary>
        public Guid ExtractorInfoId { get; set; }

        /// <summary>
        /// 文件存储Container名称
        /// </summary>
        public virtual string Container { get; set; }

        /// <summary>
        /// 文件存储的Id
        /// </summary>
        public virtual string FileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public virtual int FileType { get; set; }
    }
}
