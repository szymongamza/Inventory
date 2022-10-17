using AutoMapper;
using Inventory.Server.Resources;
using Inventory.Shared;

namespace Inventory.Server.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Department, DepartmentResource>();
            CreateMap<ServiceResponse<List<Department>>, ServiceResponse<List<DepartmentResource>>>();
            CreateMap<ServiceResponse<Department>, ServiceResponse<DepartmentResource>>();
            
            CreateMap<Room, RoomResource>();
            CreateMap<ServiceResponse<List<Room>>, ServiceResponse<List<RoomResource>>>();
            CreateMap<ServiceResponse<Room>, ServiceResponse<RoomResource>>();

            CreateMap<Device, DeviceResource>();
            CreateMap<ServiceResponse<List<Device>>, ServiceResponse<List<DeviceResource>>>();
            CreateMap<ServiceResponse<Device>, ServiceResponse<DeviceResource>>();



        }
    }
}
