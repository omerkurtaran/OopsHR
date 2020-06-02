using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
   public class EmployeeSalaryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "SalaryNameEmployeeSalaryRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeSalaryModelValidationMessage))]
        public string SalaryName { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }

    }
}
