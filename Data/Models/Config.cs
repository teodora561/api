using KbstAPI.Core.Props;

namespace KbstAPI.Data.Models
{
    public class Config
    {
        public int ID { get; set; }

        public string? Type { get; set; }

        public IDictionary<string, PropertyConfig> Properties { get; set; } = new Dictionary<string, PropertyConfig>();

    }
}
