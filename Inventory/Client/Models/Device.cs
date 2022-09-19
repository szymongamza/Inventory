
namespace Inventory.Client
{
    public class Device : IEntity
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }

}