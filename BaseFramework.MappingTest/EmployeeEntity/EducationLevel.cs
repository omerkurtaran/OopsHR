using System.Collections.Generic;

namespace BaseFramework.MappingTest.EmployeeEntity
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