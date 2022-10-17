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

        public async Task<ServiceResponse<Room>> AddAsync(Room room)
        {
            try
            {
                Console.WriteLine("DEBUG");
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Room> { Data = room };
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    return new ServiceResponse<Room> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Room> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Room>> DeleteAsync(int roomId)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (existingRoom == null)
                return new ServiceResponse<Room> { Message = "Room not found", Success = false };
            try
            {
                _context.Rooms.Remove(existingRoom);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Room> { Data = existingRoom };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Room> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Room> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Room>> UpdateAsync(int roomId, Room roomIn)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (existingRoom == null)
                return new ServiceResponse<Room> { Message = "Room not found", Success = false };
            existingRoom.RoomNumber = roomIn.RoomNumber;
            existingRoom.Floor = roomIn.Floor;
            try
            {
                _context.Rooms.Update(existingRoom);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Room> { Data = existingRoom };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Room> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Room> { Message = ex.Message, Success = false };
            }
        }

        public async Task<ServiceResponse<Room>> FindByIdAsync(int roomId)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(d => d.RoomId == roomId);
            if (existingRoom == null)
                return new ServiceResponse<Room> { Message = "Room not found", Success = false };
            return new ServiceResponse<Room> { Data = existingRoom };
        }

        public async Task<ServiceResponse<List<Room>>> FindAllByDepartmentId(int departmentId)
        {
            var existingRoom = await _context.Rooms.Where(d => d.DepartmentId == departmentId).ToListAsync();
            if (existingRoom == null)
                return new ServiceResponse<List<Room>> { Message = "Room not found", Success = false };
            return new ServiceResponse<List<Room>> { Data = existingRoom };
        }

        public async Task<ServiceResponse<List<Room>>> ListAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return new ServiceResponse<List<Room>> { Data = rooms };
        }
    }
}
