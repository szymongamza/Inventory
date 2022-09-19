using Inventory.Shared;

namespace Inventory.Server.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<Department>> CreateDepartment(Department department);
        Task<ServiceResponse<Department>> DeleteDepartment(int departmentId);
        Task<ServiceResponse<Department>> PutDepartment(int departmentId, Department departmentIn);
        Task<ServiceResponse<Department>> GetDepartment(int departmentId);
        Task<ServiceResponse<List<Department>>> GetDepartments();
    }
}