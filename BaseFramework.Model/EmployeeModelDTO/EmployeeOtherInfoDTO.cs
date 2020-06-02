using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class EmployeeOtherInfoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "AdressInfoEmployeeOtherInfoRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeOtherInfoModelValidationMessage))]
        public string AdressInfo { get; set; }

        [Required(ErrorMessageResourceName = "AdressFullEmployeeOtherInfoRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.EmployeeOtherInfoModelValidationMessage))]
        public string AdressFull { get; set; }

        public Nullable<int> HomePhone { get; set; }
        public string ContactNameforEmergency { get; set; }
        public string RelationshipforEmergencyContact { get; set; }
        public string NumberforEmergencyContact { get; set; }
        public string SocialMediaConnectionName { get; set; }
        public string SocialMediaConnectionAddress { get; set; }

        public virtual EmployeeDTO Employee { get; set; }
        public virtual DistrictDTO District { get; set; }
    }
}
