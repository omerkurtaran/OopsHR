using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class AccessType
    {
        public AccessType()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }

        public string AccessTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("OOPS.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
