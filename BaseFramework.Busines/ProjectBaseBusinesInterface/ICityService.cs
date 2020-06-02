using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface ICityService : IServiceBase
    {
        List<CityDTO> getAll();
        CityDTO getCity(int Id);
        List<CityDTO> getCityName(string cityName);
        CityDTO getCityCode(string cityCode);
        List<CityDTO> getCountryinCity(int countryId);
    }
}
