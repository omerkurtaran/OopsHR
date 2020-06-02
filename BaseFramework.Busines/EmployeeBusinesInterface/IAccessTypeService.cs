using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IAccessTypeService : IServiceBase
    {
        List<AccessTypeDTO> getAll();
        AccessTypeDTO getAccessType(int Id);
        AccessTypeDTO newAccessType(AccessTypeDTO accessType);
        AccessTypeDTO updateAccessType(AccessTypeDTO accessType);
        bool deleteAccessType(int accessTypeId);

    }
}
