using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class PermitType
    {
        public PermitType()
        {
            Permits = new HashSet<Permit>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Permit> Permits { get; set; }
    }
}
