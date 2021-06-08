using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    /// <summary>
    /// 创建提取器资源
    /// </summary>
    public class CreateExtractorInfoResourceDto
    {
        /// <summary>
        /// 文件存储Container名称
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorInfoResourceConsts), nameof(ExtractorInfoResourceConsts.MaxContainerLength))]
        public string Container { get; set; }

        /// <summary>
        /// 文件存储的Id
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorInfoResourceConsts), nameof(ExtractorInfoResourceConsts.MaxFileIdLength))]
        public string FileId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Required]
        public int FileType { get; set; }
    }
}
