using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICountryService : IServiceBase
    {
        List<CountryDTO> getAll();
        CountryDTO getCountry(int Id);
        List<CountryDTO> getCountryName(string countryName);
        CountryDTO getCountryCode(string countryCode);
        CountryDTO getCountryLangCode(string langCode);
    }
}
