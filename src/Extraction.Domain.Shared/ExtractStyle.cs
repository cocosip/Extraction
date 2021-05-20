namespace Extraction
{
    /// <summary>
    /// 提取方式(提取的内容的类型,提取到的数据不是最终的数据,比如图片的base64值)
    /// </summary>
    public enum ExtractStyle
    {
        /// <summary>
        /// 常量
        /// </summary>
        Const = 1,

        /// <summary>
        /// 通过XPath的方式
        /// </summary>
        XPath = 2
    }
}
