using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class SystemEducationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EducatorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }

        public string EducatorCompany { get; set; }
        public string EducationLocation { get; set; }
        public string ValidityPeriodMonth { get; set; }
        public string Description { get; set; }

        public List<EducationDTO> Educations { get; set; }
    }
}
