using System.Collections.Generic;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class EducationStatus
    {
        public EducationStatus()
        {
            EmployeeDetails = new HashSet<EmployeeDetail>();
        }
        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<EmployeeDetail> EmployeeDetails { get; set; }
    }
}