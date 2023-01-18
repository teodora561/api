using KbstAPI.Core.Props;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    public class ListConfig
    {
        [JsonIgnore]
        public int ID { get; set; }

        public string? Type { get; set; }

        [JsonExtensionData]
        public IDictionary<string, PropertyConfig> Properties { get; set; } = new Dictionary<string, PropertyConfig>();

    }
}
