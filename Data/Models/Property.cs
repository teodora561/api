using KbstAPI.Core.Props;
using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public bool HasCallback { get; set; }

        //public Label? Editable { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public PropertyType PropertyType { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalValues { get; set; } = new Dictionary<string, object>();

    }

    public class TextProperty : Property
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string Regex { get; set; } = String.Empty;
    }
}
