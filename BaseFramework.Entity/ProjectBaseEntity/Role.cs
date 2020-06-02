using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class Role
    {
        public Role()
        {
            Pages = new HashSet<Page>();
            UserCompanies = new HashSet<UserCompany>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsSystemRole { get; set; }

        public ICollection<UserCompany> UserCompanies { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}
