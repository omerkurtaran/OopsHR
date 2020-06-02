using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEmployeeSalaryService : IServiceBase
    {
        List<EmployeeSalaryDTO> getAll();
        EmployeeSalaryDTO getEmployeeSalary(int Id);
        EmployeeSalaryDTO newEmployeeSalary(EmployeeSalaryDTO employeeSalary);
        EmployeeSalaryDTO updateEmployeeSalary(EmployeeSalaryDTO employeeSalary);
        bool deleteEmployeeSalary(int employeeSalaryId);
    }
}
