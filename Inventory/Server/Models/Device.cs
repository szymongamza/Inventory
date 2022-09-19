using Inventory.Shared;

namespace Inventory.Server.Models
{
    public class Device : IEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public int DeviceId { get; set; }
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;
        public Room Room { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedDate { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string CreatedBy { get; set; } = string.Empty;

        [SwaggerSchema(ReadOnly = true)]
        public DateTime UpdatedDate { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string UpdatedBy { get; set; } = string.Empty;
    }

}