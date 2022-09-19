using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using Inventory.Shared;

namespace Inventory.Server
{
    public class Device:IEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;

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