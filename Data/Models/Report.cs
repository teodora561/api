using Microsoft.EntityFrameworkCore;

namespace KbstAPI.Data.Models
{
    public class Report
    {
        public int ConnectionId { get; set; }

        public string? Name { get; set; }    

        public DateTime Time { get; set; }

        public int NumberOfColumns { get; set; }
    }
}
