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
    public class CompanyBranch
    {
        public CompanyBranch()
        {
            Employees = new HashSet<Employee>();
        }
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string MersisNumber { get; set; }
        public string SSNumber { get; set; }

        [ForeignKey("Company")]
        public Nullable<int> CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [ForeignKey("District")]
        public Nullable<int> DistrictId { get; set; }
        public virtual District District { get; set; }

        public string Adress { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }


    }
}
