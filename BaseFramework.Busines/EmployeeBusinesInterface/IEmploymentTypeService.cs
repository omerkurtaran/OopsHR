using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEmploymentTypeService : IServiceBase
    {
        List<EmploymentTypeDTO> getAll();
        EmploymentTypeDTO getEmploymentType(int Id);
        EmploymentTypeDTO newEmploymentType(EmploymentTypeDTO employmentType);
        EmploymentTypeDTO updateEmploymentType(EmploymentTypeDTO employmentType);
        bool deleteEmploymentType(int employmentTypeId);
    }
}
