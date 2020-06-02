using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EmploymentTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameEmploymentTypeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmploymentTypeModelValidationMessage))]
        public string Name { get; set; }

        public List<EmployeeDTO> Employees { get; set; }


    }
}
