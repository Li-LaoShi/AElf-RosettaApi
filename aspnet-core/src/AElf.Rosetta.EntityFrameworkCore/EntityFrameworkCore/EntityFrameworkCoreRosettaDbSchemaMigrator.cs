using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AElf.Rosetta.Data;
using Volo.Abp.DependencyInjection;

namespace AElf.Rosetta.EntityFrameworkCore;

public class EntityFrameworkCoreRosettaDbSchemaMigrator
    : IRosettaDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreRosettaDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the RosettaDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<RosettaDbContext>()
            .Database
            .MigrateAsync();
    }
}
