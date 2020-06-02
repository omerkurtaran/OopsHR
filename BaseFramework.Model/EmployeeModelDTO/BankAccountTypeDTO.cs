using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class BankAccountTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameBankAccountTypeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.BankAccountTypeModelValidationMessage))]
        public string Name { get; set; }
        public List<BankInformationDTO> BankInformations { get; set; }
    }
}
