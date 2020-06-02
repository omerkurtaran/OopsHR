using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "FullNameUserRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        [MaxLength(21, ErrorMessage = "TwentyOneValidation",
            ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceName = "UserNameUserRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string UserName { get; set; }
        [Required(ErrorMessageResourceName = "PasswordUserRequiredMessage",
             ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string Password { get; set; }
        [Required(ErrorMessageResourceName = "MailUserRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string Mail { get; set; }

        [Required(ErrorMessageResourceName = "PhoneUserRequiredMessage",
           ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string Phone { get; set; }

        public string Location { get; set; }
        public string Browser { get; set; }
        public string IP { get; set; }
        public bool IsActive { get; set; }


        public List<UserCompanyDTO> UserCompanies { get; set; }

        [Required(ErrorMessageResourceName = "RoleListUserRequiredMessage",
          ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public List<int> RoleList { get; set; }

        [Required(ErrorMessageResourceName = "CompanyNameUserRequiredMessage",
          ErrorMessageResourceType = typeof(sysLanguage.UserModelValidationMessage))]
        public string CompanyName { get; set; }

        public bool Validate()
        {
            if (!string.IsNullOrEmpty(UserName) &&
                !string.IsNullOrEmpty(Mail) &&
                !string.IsNullOrEmpty(Password)) return true;
            return false;
        }
    }
}
