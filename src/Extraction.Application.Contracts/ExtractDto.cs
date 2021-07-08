namespace Extraction
{
    /// <summary>
    /// 提取输入实体
    /// </summary>
    public class ExtractDto
    {
        /// <summary>
        /// 管道名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 提取器名称
        /// </summary>
        public string ExtractorInfoName { get; set; }

        /// <summary>
        /// Html的值
        /// </summary>
        public string HtmlContent { get; set; }
    }
}
