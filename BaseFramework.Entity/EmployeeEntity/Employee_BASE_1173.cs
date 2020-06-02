using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailBusiness { get; set; }
        public string EmailPersonal { get; set; }
        public string PhoneBusiness { get; set; }
        public string PhonePersonal { get; set; }
        public DateTime StartDate { get; set; }

        [ForeignKey("EmploymentType")]
        public Nullable<int> EmploymentTypeID { get; set; }
        public virtual EmploymentType EmploymentType { get; set; }

        [ForeignKey("AccessType")]
        public Nullable<int> AccessTypeID { get; set; }
        public virtual AccessType AccessType { get; set; }

        [ForeignKey("ContractType")]
        public Nullable<int> ContractTypeID { get; set; }
        public virtual ContractType ContractType { get; set; }

        public DateTime ContractEndDate { get; set; }

        [ForeignKey("Company")]
        public Nullable<int> CompanyID { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("CompanyBranch")]
        public Nullable<int> CompanyBranchID { get; set; }
        public virtual CompanyBranch CompanyBranch { get; set; }

        [ForeignKey("CompanyDepartment")]
        public Nullable<int> CompanyDepartmentID { get; set; }
        public virtual CompanyDepartment CompanyDepartment { get; set; }

        [ForeignKey("CompanyTitle")]
        public Nullable<int> CompanyTitleID { get; set; }
        public virtual CompanyTitle CompanyTitle { get; set; }

        [ForeignKey("EmployeeSalary")]
        public Nullable<int> EmployeeSalaryID { get; set; }

        public virtual EmployeeSalary EmployeeSalary { get; set; }

    }
}
