namespace Inventory.Server.Resources
{
    public class SaveDeviceResource
    {
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        public string SerialNumber { get; set; } = string.Empty;
        public int RoomId { get; set; }
    }
}
