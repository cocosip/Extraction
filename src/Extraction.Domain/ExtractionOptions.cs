namespace Extraction
{
    public class ExtractionOptions
    {
        /// <summary>
        /// 检索匹配的数据量
        /// </summary>
        public int SearchMatch { get; set; } = 80;

        /// <summary>
        /// OCR数据路径
        /// </summary>
        public string TesseractDataPath { get; set; } = "./tessdata";

        /// <summary>
        /// OCR语言
        /// </summary>
        public string TesseractLanguage { get; set; } = "eng";
    }
}
