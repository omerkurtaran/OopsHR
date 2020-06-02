using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEducationLevelService : IServiceBase
    {
        List<EducationLevelDTO> getAll();
        EducationLevelDTO getEducationLevel(int Id);
        EducationLevelDTO newEducationLevel(EducationLevelDTO educationLevel);
        EducationLevelDTO updateEducationLevel(EducationLevelDTO educationLevel);
        bool deleteEducationLevel(int educationLevelId);
    }
}
