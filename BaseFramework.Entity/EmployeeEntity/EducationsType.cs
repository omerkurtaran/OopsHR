using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class EducationsType
    {
        public EducationsType()
        {
            Educations = new HashSet<Education>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
