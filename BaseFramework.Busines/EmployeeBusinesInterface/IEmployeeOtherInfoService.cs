using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IEmployeeOtherInfoService : IServiceBase
    {
        List<EmployeeOtherInfoDTO> getAll();
        EmployeeOtherInfoDTO getEmployeeOtherInfo(int Id);
        EmployeeOtherInfoDTO newEmployeeOtherInfo(EmployeeOtherInfoDTO employeeOtherInfo);
        EmployeeOtherInfoDTO updateEmployeeOtherInfo(EmployeeOtherInfoDTO employeeOtherInfo);
        bool deleteEmployeeOtherInfo(int employeeOtherInfoId);
    }
}
