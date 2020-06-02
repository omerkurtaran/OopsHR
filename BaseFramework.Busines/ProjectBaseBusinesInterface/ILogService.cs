using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface ILogService : IServiceBase
    {
        List<LogDTO> getAll();
        LogDTO getLog(int Id);
        LogDTO newLog(LogDTO log);
        LogDTO updateLog(LogDTO log);
        bool deleteLog(int logId);

    }
}
