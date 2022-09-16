using System.ComponentModel.DataAnnotations;

namespace Inventory.Shared
{
    public class Device
    {
        public int Id { get; set; }
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public string SerialNumber { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }

        public Device()
        {
            this.CreatedDate = DateTime.Now;
    }
    }

}