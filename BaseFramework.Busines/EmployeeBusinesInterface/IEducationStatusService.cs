using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEducationStatusService : IServiceBase
    {
        List<EducationStatusDTO> getAll();
        EducationStatusDTO getEducationStatus(int Id);
        EducationStatusDTO newEducationStatus(EducationStatusDTO educationStatus);
        EducationStatusDTO updateEducationStatus(EducationStatusDTO educationStatus);
        bool deleteEducationStatus(int educationStatusId);
    }
}
