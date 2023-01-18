using KbstAPI.Core.DTO;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KbstAPI.Services
{
    public interface IAssetService
    {
        Task<Asset> GetItemById(Guid id);
        Task<IEnumerable<Asset>> GetAssets();
        Task<GetAssetsResponse> GetAssets(Guid? parentId, string? type, string? include);
        Task<GetAssetsResponse> GetAssetsResponse(Guid id, bool includeConfig, string? recursive);
        Task<GetAssetResponse> GetAssetResponse(Guid id);
        Task<IEnumerable<AssetNode>> GetAssetNodes();
        Dictionary<string, Property> GetSchema(IDictionary<string, Property> properties);
        Task<ChangesResponse<Asset>> CreateAsset(Asset item);
        Task<ChangeResponseOneEntity<AssetNode>> CreateAssetNode(AssetNode assetNode);
        Task<ActionResult> DeleteMany(List<Guid> ids, bool force);
        Task<ChangesResponse<AssetNode>> DeleteManyNodes(List<Guid> ids);  
        void DeleteAsset(int id);
        Task<ChangesResponse<Asset>> UpdateAsset(Guid id, Asset asset);
        Task<ChangesResponse<AssetNode>> UpdateAssetNode(AssetNode assetNode);
    }
}
