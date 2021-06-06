using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    /// <summary>
    /// 添加管道资源
    /// </summary>
    public class AddExtractorProviderResourceDto
    {
        /// <summary>
        /// 文件存储Container名称
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorProviderResourceConsts), nameof(ExtractorProviderResourceConsts.MaxContainerLength))]
        public string Container { get; set; }

        /// <summary>
        /// 文件存储的Id
        /// </summary>
        [DynamicStringLength(typeof(ExtractorProviderResourceConsts), nameof(ExtractorProviderResourceConsts.MaxFileIdLength))]
        public string FileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Required]
        public int FileType { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        [Required]
        public int Order { get; set; }
    }
}
