using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IBloodGroupService : IServiceBase
    {
        List<BloodGroupDTO> getAll();
        BloodGroupDTO getBloodGroup(int Id);
        BloodGroupDTO newBloodGroup(BloodGroupDTO bloodGroup);
        BloodGroupDTO updateBloodGroup(BloodGroupDTO bloodGroup);
        bool deleteBloodGroup(int bloodGroupId);
    }
}
