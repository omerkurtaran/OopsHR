using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class OvertimeDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Hour { get; set; }
        public string Description { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
