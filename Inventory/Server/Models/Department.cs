using Inventory.Shared;

namespace Inventory.Server.Models
{
    public class Department:IEntity
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public List<Room>? Rooms { get; set; }

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
