using KbstAPI.Core.Props;
using KbstAPI.Data.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{
    public class GetAssetsResponse
    {
        public List<Asset> Entities { get; set; } = new List<Asset>();

        public Schema Schema { get; set; } = new Schema();

        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PropertiesDTO Config { get; set; } 
    }
}
