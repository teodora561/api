using KbstAPI.Core.Props;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace KbstAPI.Data.Models
{
    public class Schema
    {
        [JsonIgnore]
        public int ID { get; set; }

        /// <summary>
        /// What type this asset is
        /// </summary>
        /// <example>Log</example>
        public string Type { get; set; } = String.Empty;

        /// <summary>
        /// Instance of the type. For example "CLC Log", this is a subtype of "Log".
        /// It's optional because not all types have subtypes
        /// </summary>
        /// <example>CLC Log</example>
        public string? SubType { get; set; }

        /// <summary>
        /// Configuration of how this schema is to be rendered.
        /// Contains grouping of properties as well as placement of everything
        /// </summary>
        public LayoutConfig Template { get; set; }

        [JsonIgnore]
        public int TemplateId { get; set; }

        public PersistencyState PersistencyState { get; set; }

        /// <summary>
        /// KV pair of the property key and its value.
        /// </summary>
        public IDictionary<string, Property> Properties { get; set; } = new Dictionary<string, Property>();
    }

    public enum PersistencyState 
    { 
        New, 
        Persisted, 
        Modified, 
        Deleted
    };
        
}
