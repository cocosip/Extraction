namespace Extraction
{
    public interface IOcrService
    {

        /// <summary>
        /// 根据图片Base64获取内容
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        string Recognize(string base64);
    }
}
