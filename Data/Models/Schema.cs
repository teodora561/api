using KbstAPI.Core.Props;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    public class Schema
    {
        public int ID { get; set; }
        public string? Type { get; set; }
        public IDictionary<string, PropertyDB> Properties { get; set; } = new Dictionary<string, PropertyDB>();
    }
}
