using Inventory.Server.Data;
using Inventory.Shared;

namespace Inventory.Server.Services.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private readonly DataContext _context;
        public DeviceService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Device>> CreateDevice(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Device> { Data = device };
        }
        public async Task<ServiceResponse<Device>> DeleteDevice(int deviceId)
        {
            var response = new ServiceResponse<Device>();
            Device device = null;
            device = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if (device == null)
            {
                response.Success = false;
                response.Message = "This device does not exist.";
            }
            else
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();

            }
            return response;
        }
        public async Task<ServiceResponse<Device>> PutDevice(int deviceId, Device deviceIn)
        {
            var response = new ServiceResponse<Device>();
            Device device = null;
            device = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if (device == null)
            {
                response.Success = false;
                response.Message = "This device does not exist.";
            }
            else
            {
                device.Manufacturer = deviceIn.Manufacturer;
                device.SerialNumber = deviceIn.SerialNumber;
                device.Model = deviceIn.Model;
                await _context.SaveChangesAsync();
                response.Data = device;

            }
            return response;
        }

        public async Task<ServiceResponse<Device>> GetDevice(int deviceId)
        {
            var response = new ServiceResponse<Device>();
            Device device = null;
            device = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if(device == null)
            {
                response.Success = false;
                response.Message = "This device does not exist.";
            }
            else
            {
                response.Data = device;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Device>>> GetDevices()
        {
            var response = new ServiceResponse<List<Device>>();

            response.Data = await _context.Devices.ToListAsync();
            
            return response;
        }
    }
}
