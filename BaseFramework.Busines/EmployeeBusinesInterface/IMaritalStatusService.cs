using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IMaritalStatusService : IServiceBase
    {
        List<MaritalStatusDTO> getAll();
        MaritalStatusDTO getMaritalStatus(int Id);
        MaritalStatusDTO newMaritalStatus(MaritalStatusDTO maritalStatus);
        MaritalStatusDTO updateMaritalStatus(MaritalStatusDTO maritalStatus);
        bool deleteMaritalStatus(int maritalStatusId);
    }
}
