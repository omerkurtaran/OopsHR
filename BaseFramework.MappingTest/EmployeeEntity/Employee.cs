using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class Employee
    {
        public Employee()
        {
            BankInformations = new HashSet<BankInformation>();
            Advances = new HashSet<Advance>();
            Debits = new HashSet<Debit>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            Expenses = new HashSet<Expense>();
            Overtimes = new HashSet<Overtime>();
            VisaTypes = new HashSet<VisaType>();
            Permits = new HashSet<Permit>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailBusiness { get; set; }
        public string EmailPersonal { get; set; }
        public string PhoneBusiness { get; set; }
        public string PhonePersonal { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<BankInformation> BankInformations { get; set; }

        [ForeignKey("AccessType")]
        public Nullable<int> AccessTypeID { get; set; }
        public virtual AccessType AccessType { get; set; }

        public virtual EmployeeDetail EmployeeDetail { get; set; }
        public virtual EmployeeOtherInfo EmployeeOtherInfo { get; set; }

        [ForeignKey("ContractType")]
        public Nullable<int> ContractTypeID { get; set; }
        public virtual ContractType ContractType { get; set; }

        public virtual ICollection<Advance> Advances { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Overtime> Overtimes { get; set; }
        public virtual ICollection<VisaType> VisaTypes { get; set; }
        public virtual ICollection<Permit> Permits { get; set; }
    }
}
