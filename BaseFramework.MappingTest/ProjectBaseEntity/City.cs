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
    public class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        [ForeignKey("Country")]
        public Nullable<int> CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<District> Districts { get; set; }

    }
}
