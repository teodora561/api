using AutoMapper;
using KbstAPI.Core.IRepositories;
using KbstAPI.Core.UnitOfWork;
using KbstAPI.Data.Models;

namespace KbstAPI.Services.ConcreteServices
{
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IAssetTypeRepository _assetTypeRepository;

        public AssetTypeService(IAssetTypeRepository assetTypeRepository)
        {
            _assetTypeRepository = assetTypeRepository;
        }

        public async Task<AssetType> Create(AssetType assetType)
        {
            var res = await _assetTypeRepository.Add(assetType);
            await _assetTypeRepository.Save();

            return assetType;
        }

        public async Task<List<AssetType>> GetAssetTypes()
        {
            var types = await _assetTypeRepository.GetTypes();
            return types.ToList();
        }

        public async Task<AssetType> GetById(int id)
        {
            var type = await _assetTypeRepository.GetById(id);
            return type;
        }
    }
}
