using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MappingTest.EmployeeEntity
{
    public class Permit
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndHour { get; set; }

        public string Duration { get; set; }

        [ForeignKey("PermitType")]
        public Nullable<int> PermitTypeID { get; set; }
        public virtual PermitType PermitType { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }
        public string Signed { get; set; }
    }
}
