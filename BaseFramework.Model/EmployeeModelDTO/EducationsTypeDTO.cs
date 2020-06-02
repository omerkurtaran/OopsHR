using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EducationsTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<EducationDTO> Educations { get; set; }
    }
}
