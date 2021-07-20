using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ExtractionSample
{
    [Dependency(ReplaceServices = true)]
    public class ExtractionSampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ExtractionSample";
    }
}
