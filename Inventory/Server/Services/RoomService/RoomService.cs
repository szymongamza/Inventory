using Inventory.Server.Data;
using Inventory.Shared;

namespace Inventory.Server.Services.RoomService
{
    public class RoomService : IRoomService
    {
        private readonly DataContext _context;
        public RoomService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Room>> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Room> { Data = room };
        }
        public async Task<ServiceResponse<Room>> DeleteRoom(int roomId)
        {
            var response = new ServiceResponse<Room>();
            Room room = null;
            room = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (room == null)
            {
                response.Success = false;
                response.Message = "This room does not exist.";
            }
            else
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();

            }
            return response;
        }
        public async Task<ServiceResponse<Room>> PutRoom(int roomId, Room roomIn)
        {
            var response = new ServiceResponse<Room>();
            Room room = null;
            room = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (room == null)
            {
                response.Success = false;
                response.Message = "This room does not exist.";
            }
            else
            {
                room.Floor = roomIn.Floor;
                room.RoomNumber = roomIn.RoomNumber;
                room.Department = roomIn.Department;
                await _context.SaveChangesAsync();
                response.Data = room;

            }
            return response;
        }

        public async Task<ServiceResponse<Room>> GetRoom(int roomId)
        {
            var response = new ServiceResponse<Room>();
            Room room = null;
            room = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (room == null)
            {
                response.Success = false;
                response.Message = "This room does not exist.";
            }
            else
            {
                response.Data = room;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Room>>> GetRooms()
        {
            var response = new ServiceResponse<List<Room>>();

            response.Data = await _context.Rooms.ToListAsync();

            return response;
        }
    }
}
