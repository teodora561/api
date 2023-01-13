using KbstAPI.Core.Props;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace KbstAPI.Data.Models
{
    public class Asset
    {
        public int ID { get; set; }
        public int ParentId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? SubType { get; set; }

        /// <summary>
        /// Properties
        /// </summary>
        /// <example>{"prop1":"1", "prop2"}:true</example>
        [JsonExtensionData]
        public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }

}
