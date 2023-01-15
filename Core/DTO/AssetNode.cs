﻿using Newtonsoft.Json;

namespace KbstAPI.Core.DTO
{
    public class AssetNode
    {
        public AssetNode() { }
        public string ID { get; set; } = String.Empty;
        public string? ParentId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Type { get; set; }
        public string? SubType { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public ICollection<string> Children { get; set; }

        //[JsonExtensionData]
        //public IDictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

    }
}
