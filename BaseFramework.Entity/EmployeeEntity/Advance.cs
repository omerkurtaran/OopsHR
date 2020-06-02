using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
   public class Advance
    {
        public Advance()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; }
        public string Installment { get; set; }
        public string Description { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("OOPS.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
