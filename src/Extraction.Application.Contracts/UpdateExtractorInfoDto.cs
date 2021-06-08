using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Extraction
{
    /// <summary>
    /// 更新提取器
    /// </summary>
    public class UpdateExtractorInfoDto
    {
        /// <summary>
        /// 提取器的名称
        /// </summary>
        [Required]
        [DynamicStringLength(typeof(ExtractorInfoConsts), nameof(ExtractorInfoConsts.MaxNameLength))]
        public string Name { get; set; }

        [Required]
        [DynamicStringLength(typeof(ExtractorInfoConsts), nameof(ExtractorInfoConsts.MaxMatchLength))]
        public string Match { get; set; }

        /// <summary>
        /// 域名地址
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoConsts), nameof(ExtractorInfoConsts.MaxDomainLength))]
        public string Domain { get; set; }

        /// <summary>
        /// 提取器对应的Url地址
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoConsts), nameof(ExtractorInfoConsts.MaxUrlLength))]
        public string Url { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DynamicStringLength(typeof(ExtractorInfoConsts), nameof(ExtractorInfoConsts.MaxDescribeLength))]
        public string Describe { get; set; }
    }
}
