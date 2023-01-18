using AutoMapper;
using KbstAPI.Core.DTO;
using KbstAPI.Core.IRepositories;
using KbstAPI.Core.Props;
using KbstAPI.Core.UnitOfWork;
using KbstAPI.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace KbstAPI.Services.ConcreteServices
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<ChangesResponse<Asset>> CreateAsset(Asset asset)
        {
            await _assetRepository.Add(asset);
            await _assetRepository.Save();

            //TODO: how to generate array of changes
            var arr = new List<Asset>
                {
                    asset
                };
            return new ChangesResponse<Asset>(Array.Empty<string>(), arr);

        }

        public async void DeleteAsset(int id)
        {
            _assetRepository.Delete(id);
            await _assetRepository.Save();
        }

        public async Task<ActionResult> DeleteMany(List<Guid> ids, bool force = false)
        {
            if (force)
            {
                foreach (Guid id in ids)
                {
                    _assetRepository.Delete(id);
                }
            }
            else
            {
                foreach (Guid id in ids)
                {
                    var deleted = await _assetRepository.DeleteWithCheck(id);
                    if (!deleted)
                    {
                        await _assetRepository.Save();
                        var r = new BadRequestObjectResult($"Cannot delete asset with id {id.ToString()}");
                        return r;

                    }
                }
            }
            await _assetRepository.Save();
            var result = new ChangesResponse<Asset>();
            return new OkObjectResult(result);
        }
            
        public async Task<ChangesResponse<AssetNode>> DeleteManyNodes(List<Guid> ids)
        {
            foreach (var id in ids)
            {
                var assets = await _assetRepository.GetAssets(type: "1", parentId: id);
                var asset = await _assetRepository.GetById(id);

                var mapped = _mapper.Map<List<AssetNode>>(assets.ToList());
                var nodes = new List<AssetNode>(mapped);
                foreach (var a in assets)
                {
                    a.ParentId = asset.ParentId;
                    _assetRepository.Update(a);
                }
                
                _assetRepository.Delete(id);
                await _assetRepository.Save();
            }
            
            var result = new ChangesResponse<AssetNode>();
            return result;
        }

        public async Task<GetAssetsResponse> GetAssets(Guid? parentId, string? type, string? include)
        {

            var assets = await _assetRepository.GetAssets(parentId, type);

            var res = new GetAssetsResponse();
            res.Entities = assets.ToList();

            return res;

        }
        public async Task<IEnumerable<AssetNode>> GetAssetNodes()
        {

            var assets = await _assetRepository.GetAssets(type: "1", parentId: null);
            var mapped = _mapper.Map<List<AssetNode>>(assets.ToList());
            var nodes = new List<AssetNode>(mapped);
            var dict = new Dictionary<Guid, List<Guid>>();
            foreach (var node in nodes)
            {
                if (node.ParentId.HasValue)
                {
                    if (dict.ContainsKey((Guid)node.ParentId))
                        dict[(Guid)node.ParentId].Add(node.ID);
                    else
                        dict.Add((Guid)node.ParentId, new List<Guid>() { node.ID });
                }
            }

            foreach (var node in nodes)
            {
                node.Children = (dict.ContainsKey(node.ID)) ? dict[node.ID] : new List<Guid>();
            }
            await _assetRepository.Save();
            return nodes;

        }

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            return await this._assetRepository.GetAll();
        }

        public async Task<Asset> GetItemById(Guid id)
        {
            var asset = await _assetRepository.GetById(id);
            await _assetRepository.Save();
            return asset;
        }

        public async Task<ChangesResponse<Asset>> UpdateAsset(Guid id, Asset asset)
        {
            var a = await _assetRepository.GetById(id);
            if (a == null)
                return new ChangesResponse<Asset>(Array.Empty<string>(), new List<Asset>());
            a.Name = asset.Name;
            a.Type = asset.Type;
            a.SubType = asset.SubType;
            foreach ((string key, object property) in asset.Properties)
            {
                a.Properties[key] = property;
            }
            _assetRepository.Update(a);
            await _assetRepository.Save();
            var arr = new List<Asset>();
            arr.Add(asset);

            return new ChangesResponse<Asset>(Array.Empty<string>(), arr);

        }

        public Dictionary<string, Property> GetSchema(IDictionary<string, Property> properties)
        {
            return (Dictionary<string, Property>)properties;
        }

        public Task<ChangesResponse<Asset>> CreateAssetNode(AssetNode assetNode)
        {
            var asset = _mapper.Map<Asset>(assetNode);
            return this.CreateAsset(asset);

        }

        public async Task<GetAssetsResponse?> GetAssetsResponse(Guid id, bool includeConfig, string? recursive)
        {
            var asset = await _assetRepository.GetById(id);

            var entities = new List<Asset>();

            var schema = await _assetRepository.GetAssetSchemaForRoot(asset.SubType);
            if (recursive == "true")
            {
                entities = _assetRepository.GetChildrenRecursive(id);
            }
            else
            {
                entities = _assetRepository.GetChildren(id);
            }


            var response = new GetAssetsResponse();
            response.Entities = entities;
            if (asset.Type == null)
                return null;
            response.Schema = schema;

            if (includeConfig)
            {
                response.Config = _mapper.Map<PropertiesDTO>(_assetRepository.GetAssetConfig(asset.Type).Result);
            }

            await _assetRepository.Save();

            return response;
        }

        public async Task<GetAssetResponse?> GetAssetResponse(Guid id)
        {
            var asset = await _assetRepository.GetById(id);
            var schema = await _assetRepository.GetAssetSchema(asset.SubType);
            var response = new GetAssetResponse();
            response.Entity = asset;
            response.Schema = schema;
            return response;

        }
        public async Task<ChangesResponse<AssetNode>> UpdateAssetNode(AssetNode assetNode)
        {

            var asset = _mapper.Map<Asset>(assetNode);
            _assetRepository.Update(asset);
            var arr = new List<AssetNode>();
            arr.Add(assetNode);
            await _assetRepository.Save();
            return new ChangesResponse<AssetNode>(Array.Empty<string>(), arr);

        }
    }
}
