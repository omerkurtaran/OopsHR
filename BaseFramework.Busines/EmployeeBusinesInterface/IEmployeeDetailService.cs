using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEmployeeDetailService : IServiceBase
    {
        List<EmployeeDetailDTO> getAll();
        EmployeeDetailDTO getEmployeeDetail(int Id);
        EmployeeDetailDTO newEmployeeDetail(EmployeeDetailDTO employeeDetail);
        EmployeeDetailDTO updateEmployeeDetail(EmployeeDetailDTO employeeDetail);
        bool deleteEmployeeDetail(int employeeDetailId);
    }
}
