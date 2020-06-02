using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class BloodGroup
    {
        public BloodGroup()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
        }
        public int Id { get; set; }
        public string BloodKind { get; set; }
        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
