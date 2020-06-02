using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface ISystemEducationService : IServiceBase
    {
        List<SystemEducationDTO> getAll();
        SystemEducationDTO getSystemEducation(int Id);
        SystemEducationDTO newSystemEducation(SystemEducationDTO systemEducation);
        SystemEducationDTO updateSystemEducation(SystemEducationDTO systemEducation);
        bool deleteSystemEducation(int systemEducationId);

    }
}
