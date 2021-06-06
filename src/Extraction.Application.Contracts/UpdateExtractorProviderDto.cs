using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    public class UpdateExtractorProviderDto
    {
        /// <summary>
        /// 提取器管道名称
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorProviderConsts), nameof(ExtractorProviderConsts.MaxNameLength))]
        public string Name { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DynamicStringLength(typeof(ExtractorProviderConsts), nameof(ExtractorProviderConsts.MaxTitleLength))]
        public string Title { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DynamicStringLength(typeof(ExtractorProviderConsts), nameof(ExtractorProviderConsts.MaxDescribeLength))]
        public string Describe { get; set; }
    }
}
