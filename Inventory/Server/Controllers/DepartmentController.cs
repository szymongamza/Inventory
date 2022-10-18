using Inventory.Server.Services.DepartmentService;
using Inventory.Server.Resources;
using AutoMapper;
using Inventory.Shared;
using Microsoft.AspNetCore.Mvc;
using Inventory.Server.Extensions;

namespace Inventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DepartmentResource>>>> GetDepartmentsAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.ListAsync();
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Department>>, ServiceResponse<List<DepartmentResource>>>(result);
            return Ok(newResult);
        }

        // GET api/Department/5
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> GetDepartmentByIdAsync(int departmentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.FindByIdAsync(departmentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        //GET api/Department/5/rooms
        [HttpGet("{departmentId}/rooms")]
        public async Task<ActionResult<ServiceResponse<List<RoomResource>>>> GetRoomsByDeptIdAsync(int departmentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.ListOfRoomsAsync(departmentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Room>>, ServiceResponse<List<RoomResource>>>(result);
            return Ok(newResult);
        }

        // POST api/Department
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> PostAsync([FromBody] SaveDepartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
            var result = await _departmentService.AddAsync(department);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        // PUT api/Department/5
        [HttpPut("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> PutAsync(int departmentId, [FromBody] SaveDepartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
            var result = await _departmentService.UpdateAsync(departmentId, department);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        // DELETE api/Department/5
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> DeleteAsync(int departmentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.DeleteAsync(departmentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }
    }
}
