using KbstAPI.Data.Models;
using KbstAPI.Repository.BaseRepositories;

namespace KbstAPI.Core.IRepositories
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        
        Task<IEnumerable<Asset>> GetAssets(string? parentId, string? type);

        List<Asset> GetChildrenRecursive(string id);
        List<Asset> GetChildren(string id);

        Task<Schema> GetAssetSchema(string type);
        Task<ListConfig> GetAssetConfig(string type);

    }
}
