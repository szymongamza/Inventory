using Inventory.Server.Services.DepartmentService;
using Inventory.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Department>>>> GetDepartments()
        {
            var result = await _departmentService.GetDepartments();
            return Ok(result);
        }

        // GET api/Department/5
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<Department>>> GetDepartment(int departmentId)
        {
            var result = await _departmentService.GetDepartment(departmentId);
            return Ok(result);
        }

        // POST api/Department
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Department>>> CreateDepartment(Department department)
        {
            var result = await _departmentService.CreateDepartment(department);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }

        }

        // PUT api/Department/5
        [HttpPut("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<Department>>> PutDepartment(int departmentId, [FromBody] Department department)
        {
            var result = await _departmentService.PutDepartment(departmentId, department);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        // DELETE api/Department/5
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult<ServiceResponse<Department>>> DeleteDepartment(int departmentId)
        {
            var result = await _departmentService.DeleteDepartment(departmentId);
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
