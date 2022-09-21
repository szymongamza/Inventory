namespace Inventory.Server.Resources
{
    public class SaveRoomResource
    {
        [Required]
        public string RoomNumber { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
