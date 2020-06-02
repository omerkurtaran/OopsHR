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
    public class CityService : ICityService
    {
        private readonly IUnitofWork uow;
        public CityService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public List<CityDTO> getAll()
        {
            var getCityList = uow.GetRepository<City>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CityDTO>>(getCityList);
        }

        public CityDTO getCity(int Id)
        {
            var getCity = uow.GetRepository<City>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CityDTO>(getCity);
        }

        public CityDTO getCityCode(string cityCode)
        {
            var getCity = uow.GetRepository<City>().Get(z => z.Code == cityCode);
            return MapperFactory.CurrentMapper.Map<CityDTO>(getCity);
        }

        public List<CityDTO> getCityName(string cityName)
        {
            var getCities = uow.GetRepository<City>().Get(z => z.Name.Contains(cityName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<CityDTO>>(getCities);
        }

        public List<CityDTO> getCountryinCity(int countryId)
        {
            var getCities = uow.GetRepository<City>().Get(z => z.Country.Id == countryId, null);
            return MapperFactory.CurrentMapper.Map<List<CityDTO>>(getCities);
        }
    }
}
