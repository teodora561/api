using KbstAPI.Data.Models;

namespace KbstAPI.Services
{
    public interface IAssetTypeService
    {
        Task<AssetType> GetById(int id);
        Task<List<AssetType>> GetAssetTypes();

        Task<AssetType> Create(AssetType assetType);

    }
}
