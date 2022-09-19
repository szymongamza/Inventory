using Inventory.Server.Services.RoomService;
using Inventory.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Room>>>> GetRooms()
        {
            var result = await _roomService.GetRooms();
            return Ok(result);
        }

        // GET api/Room/5
        [HttpGet("{roomId}")]
        public async Task<ActionResult<ServiceResponse<Room>>> GetRoom(int roomId)
        {
            var result = await _roomService.GetRoom(roomId);
            return Ok(result);
        }

        // POST api/Room
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Room>>> CreateRoom(Room room)
        {
            var result = await _roomService.CreateRoom(room);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }

        // PUT api/Room/5
        [HttpPut("{roomId}")]
        public async Task<ActionResult<ServiceResponse<Room>>> PutRoom(int roomId, [FromBody] Room room)
        {
            var result = await _roomService.PutRoom(roomId, room);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // DELETE api/Room/5
        [HttpDelete("{roomId}")]
        public async Task<ActionResult<ServiceResponse<Room>>> DeleteRoom(int roomId)
        {
            var result = await _roomService.DeleteRoom(roomId);
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
