using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class ContractType
    {
        public ContractType()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string ContractName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
