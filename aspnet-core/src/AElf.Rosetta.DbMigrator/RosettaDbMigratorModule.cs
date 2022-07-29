using AElf.Rosetta.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AElf.Rosetta.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(RosettaEntityFrameworkCoreModule),
    typeof(RosettaApplicationContractsModule)
    )]
public class RosettaDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
