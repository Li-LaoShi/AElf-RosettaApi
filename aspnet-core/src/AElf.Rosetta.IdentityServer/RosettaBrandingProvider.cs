using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AElf.Rosetta;

[Dependency(ReplaceServices = true)]
public class RosettaBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Rosetta";
}
