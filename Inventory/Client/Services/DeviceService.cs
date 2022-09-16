

namespace Inventory.Client.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly HttpClient _httpClient;
        public DeviceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<Device> Devices { get; set; } = new List<Device>();

        public async Task<ServiceResponse<Device>> GetDevice(int deviceId)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Device>>($"api/Device/{deviceId}");
            return result;
        }
        public async Task GetDevices()
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Device>>>("api/Device");
            if(result != null && result.Data != null)
            {
                Devices = result.Data;
            }

        }

    }
}
