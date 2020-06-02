using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface IRoleService : IServiceBase
    {
        List<RoleDTO> getAll();
        RoleDTO newRole(RoleDTO role);
        RoleDTO updateRole(RoleDTO role);
        bool deleteRole(int roleId);
        RoleDTO getRole(int Id);

    }
}
