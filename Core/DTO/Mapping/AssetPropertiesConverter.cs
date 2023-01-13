using AutoMapper;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;

namespace KbstAPI.Core.DTO.Mapping
{
    public class AssetPropertiesConverter : ITypeConverter<Asset, AssetNode>

    {
        //public Dictionary<string, object> Convert(Dictionary<string, Property> sourceMember, ResolutionContext context)
        //{
        //    var dict = new Dictionary<string, object>();
        //    if (sourceMember.ContainsKey("icon"))
        //        dict.Add("icon", sourceMember["icon"]);
        //    if (sourceMember.ContainsKey("description"))
        //        dict.Add("description", sourceMember["description"]);
        //    return dict;
        //}
        public AssetNode Convert(Asset source, AssetNode destination, ResolutionContext context)
        {
            destination = new AssetNode();
            destination.ID = source.ID;
            destination.Name = source.Name;
            destination.ParentId = source.ParentId;
            destination.Type = source.Type;
            destination.SubType = source.SubType;

            destination.Icon = source.Properties.ContainsKey("icon") ? source.Properties["icon"].ToString() : "";
            destination.Description = source.Properties.ContainsKey("description") ? source.Properties["description"].ToString() : "";

            return destination;

        }
    }


}
