using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class UserCompanyDTO
    {
        public Nullable<int> UserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public virtual CompanyDTO Company { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual RoleDTO Role { get; set; }
    }
}
