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

        public async Task<ServiceResponse<Device>> AddAsync(Device device)
        {
            try
            {
                _context.Devices.Add(device);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Device> { Data = device };
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    return new ServiceResponse<Device> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Device> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Device>> DeleteAsync(int deviceId)
        {
            var existingDevice = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if (existingDevice == null)
                return new ServiceResponse<Device> { Message = "Device not found", Success = false };
            try
            {
                _context.Devices.Remove(existingDevice);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Device> { Data = existingDevice };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Device> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Device> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Device>> UpdateAsync(int deviceId, Device deviceIn)
        {
            var existingDevice = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if (existingDevice == null)
                return new ServiceResponse<Device> { Message = "Device not found", Success = false };

            existingDevice.Manufacturer = deviceIn.Manufacturer;
            existingDevice.SerialNumber = deviceIn.SerialNumber;
            existingDevice.Model = deviceIn.Model;
            try
            {
                _context.Devices.Update(existingDevice);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Device> { Data=existingDevice };
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Device> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Device> { Message = ex.Message, Success = false };
            }
        }

        public async Task<ServiceResponse<Device>> FindByIdAsync(int deviceId)
        {
            var existingDevice = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == deviceId);
            if (existingDevice == null)
                return new ServiceResponse<Device> { Message = "Device not found", Success = false };
            return new ServiceResponse<Device> { Data = existingDevice };
        }

        public async Task<ServiceResponse<List<Device>>> ListAsync()
        {
            var devices = await _context.Devices.ToListAsync();
            return new ServiceResponse<List<Device>> { Data = devices };
        }
    }
}
