using KbstAPI.Core.Props;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KbstAPI.Data.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public bool HasCallback { get; set; }

        //public Label? Editable { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public PropertyType PropertyType { get; set; }

    }
}
