using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EmployeeDetailDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "EmployeeEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public EmployeeDTO Employee { get; set; }

        [Required(ErrorMessageResourceName = "TCKNEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public string TCKN { get; set; }

        [Required(ErrorMessageResourceName = "BirthDateEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public string BirthDate { get; set; }

        public Nullable<int> Children { get; set; }

        [Required(ErrorMessageResourceName = "MaritalStatusEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public MaritalStatusDTO MaritalStatus { get; set; }

        [Required(ErrorMessageResourceName = "GenderEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public GenderDTO Gender { get; set; }

        public DisabilitySituationDTO DisabilitySituation { get; set; }

        [Required(ErrorMessageResourceName = "BloodGroupEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public BloodGroupDTO BloodGroup { get; set; }

        [Required(ErrorMessageResourceName = "EducationStatusEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public EducationStatusDTO EducationStatus { get; set; }

        [Required(ErrorMessageResourceName = "EducationLevelEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public EducationLevelDTO EducationLevel { get; set; }

        [Required(ErrorMessageResourceName = "LastCompletedEducationalInstitutionEmployeeDetailRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeDetailModelValidationMessage))]
        public string LastCompletedEducationalInstitution { get; set; }






    }
}
