using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface IDistrictService : IServiceBase
    {
        DistrictDTO getDistrict(int Id);
        List<DistrictDTO> getDistrictName(string DistrictName);
        DistrictDTO getDistrictCode(string DistrictCode);
        List<DistrictDTO> getCityinDistrict(int cityId);
    }
}
