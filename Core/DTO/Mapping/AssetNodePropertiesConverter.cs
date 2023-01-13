using AutoMapper;
using KbstAPI.Core.Props;
using KbstAPI.Data.Models;

namespace KbstAPI.Core.DTO.Mapping
{
    public class AssetNodePropertiesConverter : ITypeConverter<AssetNode, Asset>
    {
        public Asset Convert(AssetNode source, Asset destination, ResolutionContext context)
        {
            destination = new Asset();
            destination.ID = source.ID;
            destination.Name = source.Name;
            destination.ParentId = source.ParentId;
            destination.Type = source.Type;
            destination.SubType = source.SubType;
            destination.Properties["icon"] =  source.Icon != null ? source.Icon : "";
            destination.Properties["description"] = source.Description != null ? source.Description : "";

            return destination;
        }
    }
}
