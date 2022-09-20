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
        public async Task<ActionResult<ServiceResponse<List<DepartmentResource>>>> GetDepartments()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.GetDepartments();
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<List<Department>>, ServiceResponse<List<DepartmentResource>>>(result);
            return Ok(newResult);
        }

        // GET api/Department/5
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> GetDepartment(int departmentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.GetDepartment(departmentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        // POST api/Department
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> CreateDepartment([FromBody] SaveDepartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
            var result = await _departmentService.CreateDepartment(department);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        // PUT api/Department/5
        [HttpPut("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> PutDepartment(int departmentId, [FromBody] SaveDepartmentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var department = _mapper.Map<SaveDepartmentResource, Department>(resource);
            var result = await _departmentService.PutDepartment(departmentId, department);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }

        // DELETE api/Department/5
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<DepartmentResource>>> DeleteDepartment(int departmentId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var result = await _departmentService.DeleteDepartment(departmentId);
            if (!result.Success)
                return BadRequest(result.Message);
            var newResult = _mapper.Map<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>(result);
            return Ok(newResult);
        }
    }
}
