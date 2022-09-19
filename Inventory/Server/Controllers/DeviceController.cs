using Inventory.Server.Services.DeviceService;
using Inventory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Device>>>> GetDevices()
        {
            var result = await _deviceService.GetDevices();
            return Ok(result);
        }
        [HttpGet("{deviceId}")]
        public async Task<ActionResult<ServiceResponse<Device>>> GetDevice(int deviceId)
        {
            var result = await _deviceService.GetDevice(deviceId);
            return Ok(result);
        }
        [HttpDelete("{deviceId}")]
        public async Task<ActionResult<ServiceResponse<Device>>> DeleteDevice(int deviceId)
        {
            var result = await _deviceService.DeleteDevice(deviceId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPut("{deviceId}")]
        public async Task<ActionResult<ServiceResponse<Device>>> PutDevice(int deviceId, [FromBody]Device device)
        {
            var result = await _deviceService.PutDevice(deviceId, device);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Device>>> CreateDevice(Device device)
        {
            var result = await _deviceService.CreateDevice(device);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }
    }
}