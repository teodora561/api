using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations.Schema;

namespace KbstAPI.Data.Models
{
    public class LayoutConfig
    {
        [JsonIgnore]
        public int ID { get; set; }
        public ICollection<LayoutSection> Sections { get; set; }

    }

    public class LayoutSection
    {
        [JsonIgnore]
        public int ID { get; set; }
        /// <summary>
        /// Optional specific layout. Will map to some component / css class
        /// </summary>

        [JsonConverter(typeof(StringEnumConverter))]
        public LayoutType? Type { get; set; }

        /// <summary>
        /// Acts as an identifer right now
        /// </summary>
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Decides on how to split the columns. Mapped to grid fr right now.
        /// </summary>
        /// <example>[1,2,3]</example>
        public ICollection<int> ColumnRatio { get; set; }

        /// <summary>
        /// List of everything shown. Can be properties or groups
        /// </summary>
        public List<BaseContent> Content { get; set; }

        [ForeignKey("LayoutConfigId")]
        [JsonIgnore]
        public int? LayoutConfigId { get; set; }


    }

    public enum LayoutType
    {
        Columns, 
        ClcLog,
        DefaultLog,
        ReportConfigurator
    }


}
