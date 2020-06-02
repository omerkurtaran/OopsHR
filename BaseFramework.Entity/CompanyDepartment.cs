using BaseFramework.Entity.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseFramework.Entity
{
    public class CompanyDepartment
    {
        public CompanyDepartment()
        {
            CompanyDepartments = new HashSet<CompanyDepartment>();
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Company")]
        public Nullable<int> CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

        public virtual CompanyDepartment CompanyDepartment1 { get; set; }
    }
}
