using AutoMapper;
using KbstAPI.Data.Models;

namespace KbstAPI.Core.DTO.Mapping
{
    public class Mappings : Profile
    {
        public Mappings() {
            CreateMap<Asset, AssetNode>().ConvertUsing(new AssetPropertiesConverter());
            CreateMap<AssetNode, Asset>().ConvertUsing(new AssetNodePropertiesConverter());

            CreateMap<Schema, PropertiesDTO>();
            CreateMap<Config, PropertiesDTO>();
            
               
        
        }
        
    }
}
