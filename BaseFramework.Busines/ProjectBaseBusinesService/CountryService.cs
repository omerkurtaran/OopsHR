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
    public class CountryService : ICountryService
    {
        private readonly IUnitofWork uow;
        public CountryService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public List<CountryDTO> getAll()
        {
            var getCountryList = uow.GetRepository<Country>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CountryDTO>>(getCountryList);
        }

        public CountryDTO getCountry(int Id)
        {
            var getCountry = uow.GetRepository<Country>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CountryDTO>(getCountry);
        }

        public CountryDTO getCountryCode(string countryCode)
        {
            var getCountry = uow.GetRepository<Country>().Get(z => z.Code == countryCode);
            return MapperFactory.CurrentMapper.Map<CountryDTO>(getCountry);
        }

        public CountryDTO getCountryLangCode(string langCode)
        {
            var getCountry = uow.GetRepository<Country>().Get(z => z.LangCode == langCode);
            return MapperFactory.CurrentMapper.Map<CountryDTO>(getCountry);
        }

        public List<CountryDTO> getCountryName(string countryName)
        {
            var getCountryList = uow.GetRepository<Country>().Get(z => z.CountryName.Contains(countryName), null).ToList();
            return MapperFactory.CurrentMapper.Map<List<CountryDTO>>(getCountryList);
        }
    }
}
