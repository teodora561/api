using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{
    public class ChangesResponse<T>
    { 
        public string[] Actions { get; set; }

        [JsonInclude]
        public List<T> Entities;

        public ChangesResponse(string[] actions, List<T> entity) 
        {
            Actions = actions;
            Entities = entity;
        }

        public ChangesResponse()
        {
            Actions= Array.Empty<string>();
            Entities = new List<T>();
        }
    }
}
