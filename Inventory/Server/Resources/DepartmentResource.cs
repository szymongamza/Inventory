namespace Inventory.Server.Resources
{
    public class DepartmentResource
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
