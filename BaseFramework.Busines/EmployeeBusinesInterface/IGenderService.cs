using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IGenderService : IServiceBase
    {
        List<GenderDTO> getAll();
        GenderDTO getGender(int Id);
        GenderDTO newGender(GenderDTO gender);
        GenderDTO updateGender(GenderDTO gender);
        bool deleteGender(int genderId);
    }
}
