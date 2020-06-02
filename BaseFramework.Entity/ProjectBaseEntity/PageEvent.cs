using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.ProjectBaseEntity
{
    public class PageEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [ForeignKey("Page")]
        public Nullable<int> PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
