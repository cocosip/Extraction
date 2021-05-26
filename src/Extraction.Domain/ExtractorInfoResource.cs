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
        public virtual Guid ExtractorInfoId { get; set; }

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

        public ExtractorInfoResource()
        {

        }

        public ExtractorInfoResource(Guid id, Guid extractorInfoId, string container, string fileId, int fileType)
        {
            Id = id;
            ExtractorInfoId = extractorInfoId;
            Container = container;
            FileId = fileId;
            FileType = fileType;
        }

        public void Update(string container, string fileId, int fileType)
        {
            Container = container;
            FileId = fileId;
            FileType = fileType;
        }
    }
}
