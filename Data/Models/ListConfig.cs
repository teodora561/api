using KbstAPI.Core.Props;
using Newtonsoft.Json;

namespace KbstAPI.Data.Models
{
    public class ListConfig
    {
        [JsonIgnore]
        public int ID { get; set; }

        public string? Type { get; set; }

        public IDictionary<string, PropertyConfig> Properties { get; set; } = new Dictionary<string, PropertyConfig>();

    }
}
