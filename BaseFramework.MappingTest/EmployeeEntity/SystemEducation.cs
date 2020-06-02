using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class SystemEducation
    {
        public SystemEducation()
        {
            Educations = new HashSet<Education>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducatorName { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }

        public string EducatorCompany { get; set; }
        public string EducationLocation { get; set; }
        public string ValidityPeriodMonth { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Education> Educations { get; set; }

    }
}
