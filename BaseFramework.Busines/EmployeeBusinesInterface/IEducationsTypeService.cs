using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEducationsTypeService : IServiceBase
    {
        List<EducationsTypeDTO> getAll();
        EducationsTypeDTO getEducationsType(int Id);
        EducationsTypeDTO newEducationsType(EducationsTypeDTO educationsType);
        EducationsTypeDTO updateEducationsType(EducationsTypeDTO educationsType);
        bool deleteEducationsType(int educationsTypeId);

    }
}
