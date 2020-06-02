using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class BankInformation
    {
        public BankInformation()
        {
            Employees = new HashSet<Employee>();
            BankAccountTypes = new HashSet<BankAccountType>();
        }
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }

        public  virtual ICollection<BankAccountType> BankAccountTypes { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
