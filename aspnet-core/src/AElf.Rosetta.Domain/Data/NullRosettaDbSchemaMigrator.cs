using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AElf.Rosetta.Data;

/* This is used if database provider does't define
 * IRosettaDbSchemaMigrator implementation.
 */
public class NullRosettaDbSchemaMigrator : IRosettaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
