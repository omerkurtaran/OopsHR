using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameEmployeeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeModelValidationMessage))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "SurnameEmployeeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeModelValidationMessage))]
        public string Surname { get; set; }

        [Required(ErrorMessageResourceName = "EmailBusinessEmployeeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeModelValidationMessage))]
        public string EmailBusiness { get; set; }

        public string EmailPersonal { get; set; }

        [Required(ErrorMessageResourceName = "PhoneBusinessEmployeeRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeModelValidationMessage))]
        public string PhoneBusiness { get; set; }

        public string PhonePersonal { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ContractEndDate { get; set; }

        public List<BankInformationDTO> BankInformations { get; set; }

        public Nullable<int> AccessTypeID { get; set; }
        public AccessTypeDTO AccessType { get; set; }

        public ContractTypeDTO ContractType { get; set; }

        public EmployeeDetailDTO EmployeeDetail { get; set; }

        public EmployeeOtherInfoDTO EmployeeOtherInfo { get; set; }

        public List<AdvanceDTO> Advances { get; set; }

        public List<DebitDTO> Debits { get; set; }

        public List<EmployeeSalaryDTO> EmployeeSalaries { get; set; }

        public List<ExpenseDTO> Expenses { get; set; }

        public List<OvertimeDTO> Overtimes { get; set; }

        public List<VisaTypeDTO> VisaTypes { get; set; }

        public List<PermitDTO> Permits { get; set; }
    }
}
