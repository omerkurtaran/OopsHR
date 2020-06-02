using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IDisabilitySituationService : IServiceBase
    {
        List<DisabilitySituationDTO> getAll();
        DisabilitySituationDTO getDisabilitySituation(int Id);
        DisabilitySituationDTO newDisabilitySituation(DisabilitySituationDTO disabilitySituation);
        DisabilitySituationDTO updateDisabilitySituation(DisabilitySituationDTO disabilitySituation);
        bool deleteDisabilitySituation(int disabilitySituationId);
    }
}
