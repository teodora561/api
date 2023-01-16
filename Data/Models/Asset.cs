using KbstAPI.Core.Props;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace KbstAPI.Data.Models
{
    public class Asset
    {
        public string ID { get; set; } = String.Empty;
        public string? ParentId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public string? SubType { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        /// <example>{"prop1":"1", "prop2":true}</example>
        [JsonExtensionData]
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }

}
