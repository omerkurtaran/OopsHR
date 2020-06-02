using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EducationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int StatusId { get; set; }
        public virtual EducationsTypeDTO EducationsType { get; set; }

        public DateTime DateCompleted { get; set; }

        public List<SystemEducationDTO> SystemEducations { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
    }
}
