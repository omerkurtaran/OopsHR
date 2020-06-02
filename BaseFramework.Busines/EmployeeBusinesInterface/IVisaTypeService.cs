using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IVisaTypeService : IServiceBase
    {
        List<VisaTypeDTO> getAll();
        VisaTypeDTO getVisaType(int Id);
        VisaTypeDTO newVisaType(VisaTypeDTO VisaType);
        VisaTypeDTO updateVisaType(VisaTypeDTO VisaType);
        bool deleteVisaType(int VisaTypeId);

    }
}
