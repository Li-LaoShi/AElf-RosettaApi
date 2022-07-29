using Volo.Abp.Modularity;

namespace AElf.Rosetta;

[DependsOn(
    typeof(RosettaApplicationModule),
    typeof(RosettaDomainTestModule)
    )]
public class RosettaApplicationTestModule : AbpModule
{

}
