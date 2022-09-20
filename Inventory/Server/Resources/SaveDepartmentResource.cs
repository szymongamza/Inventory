namespace Inventory.Server.Resources
{
    public class SaveDepartmentResource
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
    }
}
