using BaseFramework.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class User
    {
        public User()
        {
            UserCompanies = new HashSet<UserCompany>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [ForeignKey("Employee")]
        public Nullable<int> EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    
    }
}
