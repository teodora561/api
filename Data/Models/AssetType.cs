
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    public class AssetType
    {
        public int ID { get; set; }

        public string? Icon { get; set; }

        public string? DisplayName { get; set; }

        [ForeignKey("ParentId")]
        public int? ParentId { get; set; }

        [JsonIgnore]
        public virtual AssetType? Parent { get; set; }   

        public ICollection<AssetType>? SubTypes { get; set; }  

    }
}
