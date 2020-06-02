using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.CompanyModel
{
    public class CompanyBranchDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "BranchNameCompanyBranchRequiredMessage",
        ErrorMessageResourceType = typeof(sysLanguage.CompanyBranchDTOModelValidationMessage))]
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string MersisNumber { get; set; }
        public string SSNumber { get; set; }
        public Nullable<int> DistrictId { get; set; }
        public virtual DistrictDTO District { get; set; }
        [Required(ErrorMessageResourceName = "CompanyIdCompanyBranchRequiredMessage",
          ErrorMessageResourceType = typeof(sysLanguage.CompanyBranchDTOModelValidationMessage))]
        public Nullable<int> CompanyId { get; set; }
        public virtual CompanyDTO Company { get; set; }
    }
}