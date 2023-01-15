using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{
    public class AssetNodesChangesResponse
    {
        public string[] Actions { get; set; }

        [JsonInclude]
        public List<AssetNode> Entities;

        public AssetNodesChangesResponse(string[] actions, List<AssetNode> entity)
        {
            Actions = actions;
            Entities = entity;
        }

        public AssetNodesChangesResponse()
        {
            Actions = Array.Empty<string>();
            Entities = new List<AssetNode>();
        }
    }
}
