﻿namespace Inventory.Server.Resources
{
    public class RoomResource
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
