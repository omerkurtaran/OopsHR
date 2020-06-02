using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
   public class EducationStatusDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "StatusNameEducationStatusRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EducationStatusModelValidationMessage))]
        public string StatusName { get; set; }
        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }

    }
}
