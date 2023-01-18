using KbstAPI.Core.Props;
using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{

    public class PropertiesDTO
    {
        [JsonExtensionData]
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    }
}
