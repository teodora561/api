using KbstAPI.Data.Models;

namespace KbstAPI.Core.DTO
{
    public class ChangeRequest
    {
        public string EventSource { get; set; }
        public Asset Entity { get; set; }
    }
}
