using KbstAPI.Data.Models;
using KbstAPI.Repository.BaseRepositories;

namespace KbstAPI.Core.IRepositories
{
    public interface IAssetRepository : IBaseRepository<Asset>
    {
        
        Task<IEnumerable<Asset>> GetAssets(int? parentId, string? type);

        List<Asset> GetChildrenRecursive(int id);
        List<Asset> GetChildren(int id);

        Task<Schema> GetAssetSchema(string type);
        Task<Config> GetAssetConfig(string type);

    }
}
