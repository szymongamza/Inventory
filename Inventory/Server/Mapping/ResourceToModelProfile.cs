using AutoMapper;
using Inventory.Server.Resources;
using Inventory.Server.Models;
namespace Inventory.Server.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<SaveRoomResource, Room>();
        }
    }
}
