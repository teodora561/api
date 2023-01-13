using KbstAPI.Data.Models;
using KbstAPI.Repository.BaseRepositories;

namespace KbstAPI.Core.IRepositories
{
    public interface IAssetTypeRepository : IBaseRepository<AssetType>
    {
        Task<IEnumerable<AssetType>> GetTypes();
    }
}
