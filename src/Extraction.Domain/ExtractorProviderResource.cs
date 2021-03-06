using System;
using Volo.Abp.Domain.Entities;

namespace Extraction
{
    /// <summary>
    /// 提取器管道资源
    /// </summary>
    public class ExtractorProviderResource : Entity<Guid>
    {
        /// <summary>
        /// 提取器管道Id
        /// </summary>
        public Guid ExtractorProviderId { get; set; }

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

        /// <summary>
        /// 顺序
        /// </summary>
        public virtual int Order { get; set; }

        public ExtractorProviderResource()
        {

        }

        public ExtractorProviderResource(
            Guid id,
            Guid extractorProviderId,
            string container,
            string fileId,
            int fileType,
            int order)
        {
            Id = id;
            ExtractorProviderId = extractorProviderId;
            Container = container;
            FileId = fileId;
            FileType = fileType;
            Order = order;
        }

        public void Update(string container, string fileId, int fileType, int order)
        {
            Container = container;
            FileId = fileId;
            FileType = fileType;
            Order = order;
        }

    }
}
