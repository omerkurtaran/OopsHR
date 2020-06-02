using BaseFramework.Model.CompanyModel;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class DistrictDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameDistrictRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.DistrictModelValidationMessage))]
        public string Name { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessageResourceName = "CityDistrictRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.DistrictModelValidationMessage))]
        public CityDTO City { get; set; }

        public List<CompanyBranchDTO> CompanyBranches { get; set; }

        public List<EmployeeOtherInfoDTO> EmployeeOtherInfos { get; set; }

    }
}
