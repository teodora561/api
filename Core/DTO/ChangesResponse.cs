using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KbstAPI.Core.DTO
{
    [NotMapped]
    public class ChangesResponse<T>
    { 
        public string[] Actions { get; set; }
        public List<T> Entities { get; set; }

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
