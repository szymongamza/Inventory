using Inventory.Server.Entity;

namespace Inventory.Server.Models
{
    public class Device : IEntity
    {
        public int DeviceId { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public string QrCode { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

}