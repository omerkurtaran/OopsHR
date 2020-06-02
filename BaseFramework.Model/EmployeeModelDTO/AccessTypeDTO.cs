using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class AccessTypeDTO
    {

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "AccessTypeNameRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.AccessTypeModelValidationMessage))]
        public string AccessTypeName { get; set; }

        public  List<EmployeeDTO> Employees { get; set; }


    }
}
