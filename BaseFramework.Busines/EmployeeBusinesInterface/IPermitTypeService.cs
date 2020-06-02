using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IPermitTypeService : IServiceBase
    {
        List<PermitTypeDTO> getAll();
        PermitTypeDTO getPermitType(int Id);
        PermitTypeDTO newPermitType(PermitTypeDTO permitType);
        PermitTypeDTO updatePermitType(PermitTypeDTO permitType);
        bool deletePermitType(int permitTypeId);
    }
}
