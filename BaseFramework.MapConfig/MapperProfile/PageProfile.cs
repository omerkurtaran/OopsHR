using BaseFramework.Core.Mapper;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.EmployeeModelDTO;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.MapperProfile
{
    public class PageProfile : ProfileBase
    {
        public PageProfile()
        {
            CreateMap<Page, PageDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Roles, src => src.Ignore())
                .ForMember(dest => dest.PageEvents, src => src.Ignore()); 
        }
    }
}
