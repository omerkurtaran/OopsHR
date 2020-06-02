using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class BloodGroupDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "BloodKindBloodGroupRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.BloodGroupModelValidationMessage))]
        public string BloodKind { get; set; }


        public List<EmployeeDetailDTO> EmployeeDetails{ get; set; }

    }
}
