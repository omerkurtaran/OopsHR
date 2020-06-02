using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class VisaType
    {
        public VisaType()
        {
            RequestForVisas = new HashSet<RequestForVisa>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestForVisa> RequestForVisas { get; set; }
    }
}
