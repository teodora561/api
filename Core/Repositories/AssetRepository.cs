using KbstAPI.Core.IRepositories;
using KbstAPI.Data;
using KbstAPI.Data.Models;
using KbstAPI.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace KbstAPI.Core.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public AssetRepository(KbstContext context) : base(context)
        {

        }

        public async Task<ListConfig> GetAssetConfig(string type)
        {
            var config = context.Configs.Where(c => c.Type == type).FirstOrDefault();
            return config;
        }

        public async Task<IEnumerable<Asset>> GetAssets(Guid? parentId, string? type)
        {
            var res = context.Assets.AsQueryable();
            if(parentId.HasValue) {
                res = res.Where(a => a.ParentId == parentId);
            }
            if(type != null)
            {
                res = res.Where(a => a.Type == type);
            }
            return res.AsEnumerable();

        }

        public async Task<Schema> GetAssetSchema(string type)
        {
            var s = context.Schemas.Where(s => s.Type == type)
                .Include(s => s.Template)
                    .ThenInclude(s => s.Sections)
                        .ThenInclude(s => s.Content)
                .FirstOrDefault();
            return s;
        }

        public List<Asset> GetChildren(Guid id)
        {
            var directChildren = context.Assets.Where(i => i.ParentId == id && i.Type != "1");
            return new List<Asset>(directChildren.ToList());
        }

        public List<Asset> GetChildrenRecursive(Guid id)
        {
            var directChildren = context.Assets.Where(i => i.ParentId == id && i.Type != "1");
            if (!directChildren.Any())
                return new List<Asset>();
            else
            {
                var children = new List<Asset>(directChildren.ToList());
                var res = new List<Asset>(children);
                foreach (var item in children)
                {
                    res.AddRange(GetChildrenRecursive(item.ID));
                }
                return res;
            }
        }

        public override void Update(Asset asset)
        {
            base.Update(asset);
        }

    }
}
