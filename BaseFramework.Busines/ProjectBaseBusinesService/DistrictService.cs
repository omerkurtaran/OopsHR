using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitofWork uow;
        public DistrictService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public List<DistrictDTO> getCityinDistrict(int cityId)
        {
            var getDistrictList = uow.GetRepository<District>().Get(z => z.City.Id == cityId, null);
            return MapperFactory.CurrentMapper.Map<List<DistrictDTO>>(getDistrictList);
        }

        public DistrictDTO getDistrict(int Id)
        {
            var getDistrict = uow.GetRepository<District>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<DistrictDTO>(getDistrict);
        }

        public DistrictDTO getDistrictCode(string DistrictCode)
        {
            var getDistrict = uow.GetRepository<District>().Get(z => z.Code == DistrictCode);
            return MapperFactory.CurrentMapper.Map<DistrictDTO>(getDistrict);
        }

        public List<DistrictDTO> getDistrictName(string DistrictName)
        {
            var getDistrict = uow.GetRepository<District>().Get(z => z.Name.Contains(DistrictName), null);
            return MapperFactory.CurrentMapper.Map<List<DistrictDTO>>(getDistrict);
        }
    }
}
