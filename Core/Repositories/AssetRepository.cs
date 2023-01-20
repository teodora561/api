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

        public async Task<Schema> GetAssetSchemaForRoot(string type)
        {
            var schema = context.Schemas.Where(s => s.Type == type && s.SubType == null)
                .Include(s => s.Template)
                    .ThenInclude(s => s.Sections)
                .FirstOrDefault();
            if(schema != null)
            foreach (var section in schema.Template.Sections.ToList())
            {
                var sectionContent = new List<BaseContent>();
                var groups = context.Groups.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(g => g.Label).ToList();
                sectionContent.AddRange(groups);
                var refs = context.PropertyRefs.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(p => p.LabelOptions).ToList();
                sectionContent.AddRange(refs);
                section.Content = sectionContent;

                var tempContent = sectionContent.ToList();

                foreach (var contentElement in tempContent)
                {
                    if (contentElement.Type == ContentType.Group)
                    {
                        (contentElement as Group).Content = GetGroupContent(contentElement.ID);
                    }
                }

                section.Content = tempContent;
            }


            return schema;
        }

        public async Task<Schema> GetAssetSchema(string type)
        {
            var schema = context.Schemas.Where(s => s.SubType == type)
                .Include(s => s.Template)
                    .ThenInclude(s => s.Sections)
                .FirstOrDefault();
            if(schema != null)
            foreach (var section in schema.Template.Sections.ToList())
            {
                var sectionContent = new List<BaseContent>();
                var groups = context.Groups.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(g => g.Label).ToList();
                sectionContent.AddRange(groups);
                var refs = context.PropertyRefs.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(p => p.LabelOptions).ToList();
                sectionContent.AddRange(refs);
                section.Content = sectionContent;

                var tempContent = sectionContent.ToList();

                foreach (var contentElement in tempContent)
                {
                    if (contentElement.Type == ContentType.Group)
                    {
                        (contentElement as Group).Content = GetGroupContent(contentElement.ID);
                    }
                }

                section.Content = tempContent;
            }


            return schema;
        }

        public async Task<Schema> GetAssetSchemaByType(string type)
        {
            var schema = context.Schemas.Where(s => s.Type == type)
                .Include(s => s.Template)
                    .ThenInclude(s => s.Sections)
                .FirstOrDefault();
            if(schema != null)
            foreach (var section in schema.Template.Sections.ToList())
            {
                var sectionContent = new List<BaseContent>();
                var groups = context.Groups.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(g => g.Label).ToList();
                sectionContent.AddRange(groups);
                var refs = context.PropertyRefs.Where(c => c.LayoutSectionId == section.ID && c.ParentId == null).Include(p => p.LabelOptions).ToList();
                sectionContent.AddRange(refs);
                section.Content = sectionContent;

                var tempContent = sectionContent.ToList();

                foreach (var contentElement in tempContent)
                {
                    if (contentElement.Type == ContentType.Group)
                    {
                        (contentElement as Group).Content = GetGroupContent(contentElement.ID);
                    }
                }

                section.Content = tempContent;
            }


            return schema;
        }

        private ICollection<BaseContent> GetGroupContent(int groupId)
        {
            var content = new List<BaseContent>();
            var groups = context.Groups.Where(c => c.ParentId == groupId).Include(g => g.Label).ToList();
            var refs = context.PropertyRefs.Where(r => r.ParentId == groupId).Include(r => r.LabelOptions).ToList();
            content.AddRange(groups);
            content.AddRange(refs);

            foreach (var g in groups)
            {

                g.Content = GetGroupContent(g.ID);
            }

            return content;

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

        //public bool Delete(Guid id, bool force)
        //{
        //    var assets = context.Assets.Where(a => a.Properties.ContainsKey(a.Name.ToLower()));
        //    if (!assets.Any() || force)
        //    {
        //        this.Delete(id); 
        //        return true;   
        //    }
        //    return false;
        //}

        public async Task<bool> DeleteWithCheck(Guid id)
        {
            var asset = await base.GetById(id);
            if (asset == null)
                return false;
            var assets = context.Assets.AsEnumerable<Asset>();
            var temp = assets.Where(a => a.Properties.ContainsKey(asset.Name.ToLower()));
            if (temp.Any())
                return false;

            base.Delete(id);
            await context.SaveChangesAsync();
            return true;
        }

        public override void Delete(Guid id)
        {
            base.Delete(id);
        }

    }
}
