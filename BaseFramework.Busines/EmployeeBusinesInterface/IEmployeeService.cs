using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEmployeeService : IServiceBase
    {
        List<EmployeeDTO> getCompanyEmployees(int companyId);
        EmployeeDTO getEmployee(int Id);
        EmployeeDTO newEmployee(EmployeeDTO employee);
        EmployeeDTO updateEmployee(EmployeeDTO employee);
        bool deleteEmployee(int employeeId);
    }
}
