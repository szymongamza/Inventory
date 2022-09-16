namespace Inventory.Client.Services
{
    public interface IDeviceService
    {
        List<Device> Devices { get; set; }
        Task<ServiceResponse<Device>> GetDevice(int deviceId);
        Task GetDevices();
    }
}
