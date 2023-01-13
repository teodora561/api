using KbstAPI.Core.Props;

namespace KbstAPI.Data.Models
{
    public class PropertyDB
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        public bool Visible { get; set; }

        public bool Editable { get; set; }

        public PropertyType PropertyType { get; set; }

    }
}
