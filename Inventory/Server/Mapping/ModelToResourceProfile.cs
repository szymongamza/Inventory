﻿using AutoMapper;
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
        }
    }
}