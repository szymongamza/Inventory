using Inventory.Shared;

namespace Inventory.Server.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<ServiceResponse<Department>> AddAsync(Department department);
        Task<ServiceResponse<Department>> DeleteAsync(int departmentId);
        Task<ServiceResponse<Department>> UpdateAsync(int departmentId, Department departmentIn);
        Task<ServiceResponse<Department>> FindByIdAsync(int departmentId);
        Task<ServiceResponse<List<Department>>> ListAsync();
        Task<ServiceResponse<List<Room>>> ListOfRoomsAsync(int departmentId);
    }
}