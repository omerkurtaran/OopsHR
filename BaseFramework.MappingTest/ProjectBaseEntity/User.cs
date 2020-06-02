using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.ProjectBaseEntity
{
    public class User
    {
        public User()
        {
            //Companies = new HashSet<Company>();
            //Roles = new HashSet<Role>();
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

        public ICollection<UserCompany> UserCompanies { get; set; }

        //public virtual ICollection<Company> Companies { get; set; }
        //public virtual ICollection<Role> Roles { get; set; }
    }
}
