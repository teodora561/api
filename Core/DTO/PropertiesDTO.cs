using KbstAPI.Core.Props;
using Newtonsoft.Json;

namespace KbstAPI.Core.DTO
{

    public class PropertiesDTO
    {
        [JsonExtensionData]
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    }
}
