using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IOvertimeService : IServiceBase
    {
        List<OvertimeDTO> getAll();
        OvertimeDTO getOvertime(int Id);
        OvertimeDTO newOvertime(OvertimeDTO Overtime);
        OvertimeDTO updateOvertime(OvertimeDTO Overtime);
        bool deleteOvertime(int OvertimeId);
    }
}
