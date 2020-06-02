using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class ContractTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ContractNameContractTypeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.ContractTypeModelValidationMessage))]
        public string ContractName { get; set; }

        public List<EmployeeDTO> Employees { get; set; }


    }
}
