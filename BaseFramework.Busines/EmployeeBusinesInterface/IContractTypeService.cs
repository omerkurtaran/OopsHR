using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IContractTypeService : IServiceBase
    {
        List<ContractTypeDTO> getAll();
        ContractTypeDTO getContractType(int Id);
        ContractTypeDTO newContractType(ContractTypeDTO contractType);
        ContractTypeDTO updateContractType(ContractTypeDTO contractType);
        bool deleteContractType(int contractTypeId);
    }
}
