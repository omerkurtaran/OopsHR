using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Entity.ProjectBaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity
{
    public class Company
    {
        public Company()
        {
            CompanyBranches = new HashSet<CompanyBranch>();
            CompanyDepartments = new HashSet<CompanyDepartment>();
            CompanyTitles = new HashSet<CompanyTitle>();
            UserCompanies = new HashSet<UserCompany>();
        }
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string MersisNumber { get; set; }
        public string SSNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<CompanyTitle> CompanyTitles { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }

        public int DistrictId { get; set; }
        //seed data hatası verdiği için eklendi
    }
}
