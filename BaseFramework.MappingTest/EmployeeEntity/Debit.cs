using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class Debit
    {
        public Debit()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Description { get; set; }

        [ForeignKey("DebitCategory")]
        public int DebitCategoryId { get; set; }
        public virtual DebitCategory DebitCategory { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
