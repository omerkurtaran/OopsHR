using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class MaritalStatus
    {
        public MaritalStatus()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
        }
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }

}
