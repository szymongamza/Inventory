namespace Inventory.Shared
{
    public class Device
    {
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateOnly BuyDate { get; set; }
        public DateOnly GuaranteeExpirationDate { get; set; }
        public List<DateOnly>? ListOfDatesOfLastCalibration { get; set; }
        public List<DateOnly>? ListOfDatesOfLastMaintainance { get; set; }
        public DateOnly DateOfNextCalibration { get; set; }
        public DateOnly DateOfNextMaintainance { get; set; }
        public string? ServiceContact { get; set; }
        public string? Hash { get; set; }
    }
}