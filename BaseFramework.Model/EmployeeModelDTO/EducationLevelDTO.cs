using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EducationLevelDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameEducationLevelRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EducationLevelModelValidationMessage))]
        public string EducationLevelName { get; set; }

        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }


    }
}
