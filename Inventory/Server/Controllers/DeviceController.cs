using Inventory.Server.Services.DeviceService;
using Inventory.Server.Resources;
using AutoMapper;
using Inventory.Shared;
using Microsoft.AspNetCore.Mvc;
using Inventory.Server.Extensions;

namespace Inventory.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly IMapper _mapper;
        public DeviceController(IDeviceService deviceService, IMapper mapper)
        {
            _deviceService = deviceService;
            _mapper = mapper;
        }

        // GET: api/Device
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Device>>>> GetDevices()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _deviceService.ListAsync();
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Device>>, ServiceResponse< List < DeviceResource >>>(result);
            return Ok(newResult);
        }

        // GET api/Device/5
        [HttpGet("{deviceId}")]
        public async Task<ActionResult<ServiceResponse<DeviceResource>>> GetAsync(int deviceId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _deviceService.FindByIdAsync(deviceId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Device>, ServiceResponse<DeviceResource>>(result);
            return Ok(newResult);
        }

        // POST api/Device
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DeviceResource>>> PostAsync([FromBody] SaveDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var device = _mapper.Map<SaveDeviceResource, Device>(resource);
            var result = await _deviceService.AddAsync(device);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Device>, ServiceResponse<DeviceResource>>(result);
            return Ok(newResult);
        }
        // PUT api/Device/5
        [HttpPut("{deviceId}")]
        public async Task<ActionResult<ServiceResponse<DeviceResource>>> PutAsync(int deviceId, [FromBody] SaveDeviceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var device = _mapper.Map<SaveDeviceResource, Device>(resource);
            var result = await _deviceService.UpdateAsync(deviceId, device);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Device>, ServiceResponse<DeviceResource>>(result);
            return Ok(newResult);
        }

        // DELETE api/Device/5
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DeviceResource>>> DeleteAsync(int deviceId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _deviceService.DeleteAsync(deviceId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Device>, ServiceResponse<DeviceResource>>(result);
            return Ok(newResult);
        }
    }
}