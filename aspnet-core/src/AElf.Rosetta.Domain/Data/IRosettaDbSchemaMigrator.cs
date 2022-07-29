using System.Threading.Tasks;

namespace AElf.Rosetta.Data;

public interface IRosettaDbSchemaMigrator
{
    Task MigrateAsync();
}
