using Inventory.Shared;

namespace Inventory.Server.Services.DeviceService
{
    public interface IDeviceService
    {
        Task<ServiceResponse<Device>> AddAsync(Device device);
        Task<ServiceResponse<Device>> DeleteAsync(int deviceId);
        Task<ServiceResponse<Device>> UpdateAsync(int deviceId, Device deviceIn);
        Task<ServiceResponse<Device>> FindByIdAsync(int deviceId);
        Task<ServiceResponse<List<Device>>> ListAsync();
    }
}