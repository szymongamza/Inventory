using Inventory.Shared;

namespace Inventory.Server.Services.RoomService
{
    public interface IRoomService
    {
        Task<ServiceResponse<Room>> AddAsync(Room room);
        Task<ServiceResponse<Room>> DeleteAsync(int roomId);
        Task<ServiceResponse<Room>> UpdateAsync(int roomId, Room roomIn);
        Task<ServiceResponse<Room>> FindByIdAsync(int roomId);
        Task<ServiceResponse<List<Room>>> ListAsync();
        Task<ServiceResponse<List<Device>>> ListOfDevicesAsync(int roomId);
    }
}
