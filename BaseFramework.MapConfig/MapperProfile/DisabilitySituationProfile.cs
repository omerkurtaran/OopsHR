using BaseFramework.Core.Mapper;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.MapperProfile
{
    public class DisabilitySituationProfile : ProfileBase
    {
        public DisabilitySituationProfile()
        {
            CreateMap<DisabilitySituation, DisabilitySituationDTO>().ReverseMap();
        }
    }
}
