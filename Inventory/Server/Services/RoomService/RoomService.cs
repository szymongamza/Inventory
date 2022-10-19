using Inventory.Server.Data;

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

        public async Task<ServiceResponse<List<Room>>> ListAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            if(!rooms.Any())
                return new ServiceResponse<List<Room>> { Message = "There are no rooms", Success = false };
            return new ServiceResponse<List<Room>> { Data = rooms };
        }
        public async Task<ServiceResponse<List<Device>>> ListOfDevicesAsync(int roomId)
        {
            var devices = await _context.Devices.Where(d => d.RoomId == roomId).ToListAsync();
            if (!devices.Any())
                return new ServiceResponse<List<Device>> { Message = "There are no devices or there is no such room", Success = false };
            return new ServiceResponse<List<Device>> { Data = devices };
        }
    }
}
