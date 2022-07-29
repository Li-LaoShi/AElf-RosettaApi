using AElf.Rosetta.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AElf.Rosetta;

[DependsOn(
    typeof(RosettaEntityFrameworkCoreTestModule)
    )]
public class RosettaDomainTestModule : AbpModule
{

}
