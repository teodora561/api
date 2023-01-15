using KbstAPI.Data.Models;

namespace KbstAPI.Core.DTO
{
    public class GetAssetResponse
    {
        public Schema Schema { get; set; } = new Schema();

        public Asset Entity { get; set; } = new Asset();
    }
}
