using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class BankInformationDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "BankNameBankInformationRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.BankInformationModelValidationMessage))]
        public string BankName { get; set; }

        [Required(ErrorMessageResourceName = "AccountNumberBankInformationRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.BankInformationModelValidationMessage))]
        public string AccountNumber { get; set; }

        [Required(ErrorMessageResourceName = "IBANBankInformationRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.BankInformationModelValidationMessage))]
        public string IBAN { get; set; }

        public List<BankAccountTypeDTO> BankAccountType { get; set; }

        public List<EmployeeDTO> Employees { get; set; }

    }
}
