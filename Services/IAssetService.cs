using KbstAPI.Core.DTO;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;

namespace KbstAPI.Services
{
    public interface IAssetService
    {
        Task<Asset> GetItemById(int id);
        Task<IEnumerable<Asset>> GetAssets();
        Task<GETResponse> GetAssets(int? parentId, string? type, string? include);

        Task<GETResponse> GetAssetsResponse(int id, bool includeConfig, bool includeChildren, string? recursive);

        Task<IEnumerable<AssetNode>> GetAssetNodes();

        Dictionary<string, Property> GetSchema(IDictionary<string, Property> properties);

        Task<ChangesResponse<Asset>> CreateAsset(Asset item);
        Task<ChangesResponse<Asset>> CreateAssetNode(AssetNode assetNode);

        Task<ChangesResponse<Asset>> DeleteMany(List<int> ids);

        void DeleteAsset(int id);
        Task<ChangesResponse<Asset>> UpdateAsset(int id, Asset asset);
        Task<ChangesResponse<AssetNode>> UpdateAssetNode(AssetNode assetNode);
    }
}
