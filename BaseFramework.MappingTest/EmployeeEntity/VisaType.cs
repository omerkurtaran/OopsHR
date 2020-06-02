using System.Collections.Generic;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class VisaType
    {
        public VisaType()
        {
            RequestForVisas = new HashSet<RequestForVisa>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestForVisa> RequestForVisas { get; set; }
    }
}
