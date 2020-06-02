using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class EducationLevel
    {
        public EducationLevel()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
        }
        public int Id { get; set; }
        public string EducationLevelName { get; set; }

        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }
}
