using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class GenderDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "GenderNameGenderRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.GenderModelValidationMessage))]
        public string GenderName { get; set; }

        public List<EmployeeDetailDTO> EmployeeDetails { get; set; }

    }
}
