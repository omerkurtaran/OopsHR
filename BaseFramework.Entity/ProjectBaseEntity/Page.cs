using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class Page
    {
        public Page()
        {
            PageEvents = new HashSet<PageEvent>();
            Roles = new HashSet<Role>();
        }
        public int Id { get; set; }
        public Nullable<int> SubPageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual ICollection<PageEvent> PageEvents { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
