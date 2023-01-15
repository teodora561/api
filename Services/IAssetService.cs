using KbstAPI.Core.DTO;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;

namespace KbstAPI.Services
{
    public interface IAssetService
    {
        Task<Asset> GetItemById(int id);
        Task<IEnumerable<Asset>> GetAssets();
        Task<GetAssetsResponse> GetAssets(string? parentId, string? type, string? include);

        Task<GetAssetsResponse> GetAssetsResponse(string id, bool includeConfig, bool includeChildren, string? recursive);

        Task<IEnumerable<AssetNode>> GetAssetNodes();

        Dictionary<string, Property> GetSchema(IDictionary<string, Property> properties);

        Task<ChangesResponse<Asset>> CreateAsset(Asset item);
        Task<ChangesResponse<Asset>> CreateAssetNode(AssetNode assetNode);

        Task<ChangesResponse<Asset>> DeleteMany(List<string> ids);

        void DeleteAsset(int id);
        Task<ChangesResponse<Asset>> UpdateAsset(int istringd, Asset asset);
        Task<ChangesResponse<AssetNode>> UpdateAssetNode(AssetNode assetNode);
    }
}
