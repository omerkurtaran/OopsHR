using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IAdvanceService : IServiceBase
    {
        List<AdvanceDTO> getAll();
        AdvanceDTO getAdvance(int Id);
        AdvanceDTO newAdvance(AdvanceDTO advance);
        AdvanceDTO updateAdvance(AdvanceDTO advance);
        bool deleteAdvance(int advanceId);
    }
}
