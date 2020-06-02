using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class Overtime
    {
        public Overtime()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan Hour { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
