namespace Extraction
{
    /// <summary>
    /// 针对提取到的数据的处理方式
    /// </summary>
    public enum HandleStyle
    {
        /// <summary>
        /// 默认,直接使用提取到的数据
        /// </summary>
        Default = 1,

        /// <summary>
        /// OCR识别
        /// </summary>
        Ocr = 2
    }
}
