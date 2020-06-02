using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class Expense
    {
        public Expense()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Plug { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
