using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.MapperProfile
{
    public class CityProfile : ProfileBase
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
        }
    }
}
