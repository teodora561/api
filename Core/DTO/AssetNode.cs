using Newtonsoft.Json;

namespace KbstAPI.Core.DTO
{
    public class AssetNode
    {
        public AssetNode() { }
        public Guid ID { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public ICollection<Guid> Children { get; set; }

        //[JsonExtensionData]
        //public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    }
}
