using Inventory.Server.Services.RoomService;
using Inventory.Server.Resources;
using AutoMapper;
using Inventory.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Inventory.Server.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<RoomResource>>>> GetRoomsAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _roomService.ListAsync();
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Room>>, ServiceResponse<List<RoomResource>>>(result);
            return Ok(newResult);
        }

        // GET api/Room/5
        [HttpGet("{roomId}")]
        public async Task<ActionResult<ServiceResponse<RoomResource>>> GetRoomByIdAsync(int roomId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _roomService.FindByIdAsync(roomId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Room>, ServiceResponse<RoomResource>>(result);
            return Ok(newResult);
        }

        //GET api/Room/5/devices
        [HttpGet("{roomId}/devices")]
        public async Task<ActionResult<ServiceResponse<List<DeviceResource>>>> GetDevicesByRoomAsync(int roomId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _roomService.ListOfDevicesAsync(roomId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Device>>, ServiceResponse<List<DeviceResource>>>(result);
            return Ok(newResult);
        }

        // POST api/Room
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<RoomResource>>> PostAsync([FromBody] SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.AddAsync(room);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Room>, ServiceResponse<RoomResource>>(result);
            return Ok(newResult);
        }

        // PUT api/Room/5
        [HttpPut("{roomId}")]
        public async Task<ActionResult<ServiceResponse<RoomResource>>> PutAsync(int roomId, [FromBody] SaveRoomResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var room = _mapper.Map<SaveRoomResource, Room>(resource);
            var result = await _roomService.UpdateAsync(roomId, room);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Room>, ServiceResponse<RoomResource>>(result);
            return Ok(newResult);
        }

        // DELETE api/Room/5
        [HttpDelete("{roomId}")]
        public async Task<ActionResult<ServiceResponse<RoomResource>>> DeleteAsync(int roomId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _roomService.DeleteAsync(roomId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Room>, ServiceResponse<RoomResource>>(result);
            return Ok(newResult);
        }
    }
}
