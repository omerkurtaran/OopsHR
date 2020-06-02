using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class DisabilitySituationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "DisabilityNameDisabilitySituationRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.DisabilitySituationModelValidationMessage))]
        public string DisabilityName { get; set; }

        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }


    }
}
