using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
   public class MaritalStatusDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "StatusNameMaritalStatusRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.MaritalStatusModelValidationMessage))]
        public string StatusName { get; set; }

        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }

    }
}
