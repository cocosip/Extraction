using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using Tesseract;
using Volo.Abp.DependencyInjection;

namespace Extraction
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(IOcrService))]
    public class TesseractOcrService : IOcrService, ITransientDependency
    {
        protected ExtractionOptions Options { get; }
        protected ILogger Logger { get; }
        public TesseractOcrService(
            IOptions<ExtractionOptions> options,
            ILogger<TesseractOcrService> logger)
        {
            Options = options.Value;
            Logger = logger;
        }

        /// <summary>
        /// 根据图片Base64获取内容
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public virtual string Recognize(string base64)
        {
            var sb = new StringBuilder();

            try
            {
                base64 = ParseBase64Image(base64);
                var buffer = Convert.FromBase64String(base64);
                using var engine = new TesseractEngine(Options.TesseractDataPath, Options.TesseractLanguage, EngineMode.Default);
                using var img = Pix.LoadFromMemory(buffer);
                using var page = engine.Process(img);
                var text = page.GetText();
                Logger.LogDebug("Mean confidence: {0}", page.GetMeanConfidence());

                //Console.WriteLine("Text (GetText): \r\n{0}", text);
                //Console.WriteLine("Text (iterator):");
                using var iter = page.GetIterator();
                iter.Begin();
                
                do
                {
                    do
                    {
                        do
                        {
                            do
                            {
                                if (iter.IsAtBeginningOf(PageIteratorLevel.Block))
                                {
                                    //Console.WriteLine("<BLOCK>");
                                    sb.AppendLine("");
                                }

                                sb.Append(iter.GetText(PageIteratorLevel.Word));
                                //Console.Write(iter.GetText(PageIteratorLevel.Word));
                                //Console.Write(" ");

                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine, PageIteratorLevel.Word))
                                {
                                    sb.AppendLine(" ");
                                    //Console.WriteLine();
                                }
                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));

                            if (iter.IsAtFinalOf(PageIteratorLevel.Para, PageIteratorLevel.TextLine))
                            {
                                sb.AppendLine(" ");
                                //Console.WriteLine();
                            }
                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                } while (iter.Next(PageIteratorLevel.Block));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "OCR 提取数据出错:{0}.", ex.Message);
            }
            return sb.ToString();
        }

        protected virtual string ParseBase64Image(string base64)
        {
            if (base64.StartsWith("data"))
            {
                return base64.Substring(base64.IndexOf(","), base64.Length - base64.IndexOf(",") + 1);
            }
            return base64;
        }
    }
}
