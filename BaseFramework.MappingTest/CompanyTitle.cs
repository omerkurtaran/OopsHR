using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest
{
    public class CompanyTitle
    {
      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Company")]
        public Nullable<int> CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
