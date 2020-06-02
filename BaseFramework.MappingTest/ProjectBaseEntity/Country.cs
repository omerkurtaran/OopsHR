using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.ProjectBaseEntity
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }
        public string LangCode { get; set; }
        public string Code { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    }
}
