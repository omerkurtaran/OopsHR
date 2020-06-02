using BaseFramework.MappingTest.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.ProjectBaseEntity
{
    public class District
    {
        public District()
        {
            CompanyBranches = new HashSet<CompanyBranch>();
            EmployeeOtherInfos = new HashSet<EmployeeOtherInfo>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [ForeignKey("City")]
        public Nullable<int> CityId { get; set; }
        public virtual City City { get; set; }

        public ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<EmployeeOtherInfo> EmployeeOtherInfos { get; set; }

    }
}
