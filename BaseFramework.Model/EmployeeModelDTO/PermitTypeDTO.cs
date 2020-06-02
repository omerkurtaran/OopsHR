using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class PermitTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NamePermitTypeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.PermitTypeModelValidationMessage))]
        public string Name { get; set; }

        public List<PermitDTO> Permits { get; set; }
    }
}
