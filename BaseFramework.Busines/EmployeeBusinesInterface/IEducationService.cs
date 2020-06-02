using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEducationService : IServiceBase
    {
        List<EducationDTO> getAll();
        EducationDTO getEducation(int Id);
        EducationDTO newEducation(EducationDTO Education);
        EducationDTO updateEducation(EducationDTO Education);
        bool deleteEducation(int EducationId);
    }
}
