using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class PermitDTO
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndHour { get; set; }
        public string Duration { get; set; }

        public PermitTypeDTO PermitType { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }
        public string Signed { get; set; }
    }
}
