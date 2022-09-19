using Inventory.Shared;

namespace Inventory.Server.Services.DeviceService
{
    public interface IDeviceService
    {
        Task<ServiceResponse<Device>> CreateDevice(Device device);
        Task<ServiceResponse<Device>> DeleteDevice(int deviceId);
        Task<ServiceResponse<Device>> PutDevice(int deviceId, Device deviceIn);
        Task<ServiceResponse<Device>> GetDevice(int deviceId);
        Task<ServiceResponse<List<Device>>> GetDevices();
    }
}