using Volo.Abp.Settings;

namespace ExtractionSample.Settings
{
    public class ExtractionSampleSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ExtractionSampleSettings.MySetting1));
        }
    }
}
