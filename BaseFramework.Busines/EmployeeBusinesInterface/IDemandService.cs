using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IDemandService : IServiceBase
    {
        List<DemandDTO> getAll();
        DemandDTO getDemand(int Id);
        DemandDTO newDemand(DemandDTO demand);
        DemandDTO updateDemand(DemandDTO demand);
        bool deleteDemand(int demandId);

    }
}
