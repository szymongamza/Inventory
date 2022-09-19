using Inventory.Server.Data;
using Inventory.Shared;

namespace Inventory.Server.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Department>> CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Department> { Data = department };
        }
        public async Task<ServiceResponse<Department>> DeleteDepartment(int departmentId)
        {
            var response = new ServiceResponse<Department>();
            Department department = null;
            department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (department == null)
            {
                response.Success = false;
                response.Message = "This department does not exist.";
            }
            else
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();

            }
            return response;
        }
        public async Task<ServiceResponse<Department>> PutDepartment(int departmentId, Department departmentIn)
        {
            var response = new ServiceResponse<Department>();
            Department department = null;
            department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (department == null)
            {
                response.Success = false;
                response.Message = "This department does not exist.";
            }
            else
            {
                department.Name = departmentIn.Name;
                department.BuildingNumber = departmentIn.BuildingNumber;
                department.Rooms = departmentIn.Rooms;
                department.Street = departmentIn.Street;
                department.City = departmentIn.City;
                department.StreetNumber = departmentIn.StreetNumber;
                await _context.SaveChangesAsync();
                response.Data = department;

            }
            return response;
        }

        public async Task<ServiceResponse<Department>> GetDepartment(int departmentId)
        {
            var response = new ServiceResponse<Department>();
            Department department = null;
            department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (department == null)
            {
                response.Success = false;
                response.Message = "This department does not exist.";
            }
            else
            {
                response.Data = department;
            }
            return response;
        }

        public async Task<ServiceResponse<List<Department>>> GetDepartments()
        {
            var response = new ServiceResponse<List<Department>>();

            response.Data = await _context.Departments.ToListAsync();

            return response;
        }
    }
}
