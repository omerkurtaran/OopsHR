using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
   public class Education
    {
        public Education()
        {
            Employees = new HashSet<Employee>();
            SystemEducations = new HashSet<SystemEducation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("EducationsType")]
        public int StatusId { get; set; }
        public virtual EducationsType EducationsType { get; set; }

        public DateTime DateCompleted { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SystemEducation> SystemEducations { get; set; }
    }
}
