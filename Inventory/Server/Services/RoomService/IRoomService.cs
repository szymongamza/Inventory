using Inventory.Shared;

namespace Inventory.Server.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<Room>> CreateRoom(Room room);
        Task<ServiceResponse<Room>> DeleteRoom(int roomId);
        Task<ServiceResponse<Room>> PutRoom(int roomId, Room roomIn);
        Task<ServiceResponse<Room>> GetRoom(int roomId);
        Task<ServiceResponse<List<Room>>> GetRooms();
    }
}
