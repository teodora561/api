using KbstAPI.Data.Models;
using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{
    public class AssetChangesResponse
    {
        public string[] Actions { get; set; }

        public List<Asset> Entities { get; set; }

        public AssetChangesResponse(string[] actions, List<Asset> entity)
        {
            Actions = actions;
            Entities = entity;
        }

        public AssetChangesResponse()
        {
            Actions = Array.Empty<string>();
            Entities = new List<Asset>();
        }
    }

}
