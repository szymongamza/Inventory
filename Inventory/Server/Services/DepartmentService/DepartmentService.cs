using Inventory.Server.Data;

namespace Inventory.Server.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Department>> AddAsync(Department department)
        {
            try
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Department> { Data = department };
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null)
                    return new ServiceResponse<Department> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Department> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Department>> DeleteAsync(int departmentId)
        {
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (existingDepartment == null)
                return new ServiceResponse<Department> { Message = "Department not found", Success = false };
            try
            {
                _context.Departments.Remove(existingDepartment);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Department> { Data = existingDepartment };
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Department> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Department> { Message = ex.Message, Success = false };
            }
        }
        public async Task<ServiceResponse<Department>> UpdateAsync(int departmentId, Department departmentIn)
        {
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (existingDepartment == null)
                return new ServiceResponse<Department> { Message = "Department not found", Success = false };
            existingDepartment.Name = departmentIn.Name;
            existingDepartment.BuildingNumber = departmentIn.BuildingNumber;
            existingDepartment.Rooms = departmentIn.Rooms;
            existingDepartment.Street = departmentIn.Street;
            existingDepartment.City = departmentIn.City;
            existingDepartment.StreetNumber = departmentIn.StreetNumber;
            try
            {
                _context.Departments.Update(existingDepartment);
                await _context.SaveChangesAsync();
                return new ServiceResponse<Department> { Data = existingDepartment};
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null)
                    return new ServiceResponse<Department> { Message = ex.InnerException.Message, Success = false };
                return new ServiceResponse<Department> { Message = ex.Message, Success = false };
            }
        }

        public async Task<ServiceResponse<Department>> FindByIdAsync(int departmentId)
        {
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
            if (existingDepartment == null)
                return new ServiceResponse<Department> { Message = "Department not found", Success = false };
            return new ServiceResponse<Department> { Data = existingDepartment };
        }

        public async Task<ServiceResponse<List<Department>>> ListAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            if(!departments.Any())
                return new ServiceResponse<List<Department>> { Message = "There are no departments", Success = false };
            return new ServiceResponse<List<Department>> { Data = departments };
        }    
        public async Task<ServiceResponse<List<Room>>> ListOfRoomsAsync(int departmentId)
        {
            var rooms = await _context.Rooms.Where(d => d.DepartmentId == departmentId).ToListAsync();
            if (!rooms.Any())
                return new ServiceResponse<List<Room>> { Message = "There are no rooms or there is no such department", Success = false };
            return new ServiceResponse<List<Room>> { Data = rooms };
        }
    }
}
