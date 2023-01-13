using KbstAPI.Core.IRepositories;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using KbstAPI.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KbstAPI.Core.Repositories
{
    public class AssetTypeRepository : BaseRepository<AssetType>, IAssetTypeRepository
    {
        public AssetTypeRepository(KbstContext context) : base(context) { }

        public async Task<IEnumerable<AssetType>> GetTypes()
        {
            var res = context.AssetTypes.Where(a => a.ParentId.HasValue == false).Include(a => a.SubTypes);
            return res.AsEnumerable();
        }
    }
}
