using Volo.Abp.Settings;

namespace AElf.Rosetta.Settings;

public class RosettaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(RosettaSettings.MySetting1));
    }
}
