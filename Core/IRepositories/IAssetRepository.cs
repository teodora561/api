using KbstAPI.Core.DTO;
using KbstAPI.Data.Models;
using KbstAPI.Repository.BaseRepositories;

namespace KbstAPI.Core.IRepositories
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        
        Task<IEnumerable<Asset>> GetAssets(Guid? parentId, string? type);

        List<Asset> GetChildrenRecursive(Guid id);
        List<Asset> GetChildren(Guid id);

        Task<Schema> GetAssetSchema(string type);
        Task<Schema> GetAssetSchemaForRoot(string type);
        Task<ListConfig> GetAssetConfig(string type);
        Task<bool> DeleteWithCheck(Guid id);

    }
}
