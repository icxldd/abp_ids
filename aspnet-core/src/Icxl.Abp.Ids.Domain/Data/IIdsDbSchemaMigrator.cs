using System.Threading.Tasks;

namespace Icxl.Abp.Ids.Data
{
    public interface IIdsDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
