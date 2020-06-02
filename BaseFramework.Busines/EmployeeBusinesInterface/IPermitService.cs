using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IPermitService : IServiceBase
    {
        List<PermitDTO> getAll();
        PermitDTO getPermit(int Id);
        PermitDTO newPermit(PermitDTO permit);
        PermitDTO updatePermit(PermitDTO permit);
        bool deletePermit(int permitId);
    }
}
