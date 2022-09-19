using Inventory.Shared;

namespace Inventory.Server.Models
{
    public class Room : IEntity
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        [Required]
        public Department department { get; set; }

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
