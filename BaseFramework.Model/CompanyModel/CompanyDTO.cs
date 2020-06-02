using BaseFramework.Model.EmployeeModelDTO;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.CompanyModel
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameCompanyRequiredMessage",
          ErrorMessageResourceType = typeof(sysLanguage.CompanyDTOModelValidationMessage))]
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public string MersisNumber { get; set; }
        public string SSNumber { get; set; }
        public string Address { get; set; }
        
        public virtual List<CompanyBranchDTO> CompanyBrancheList { get; set; }
        public virtual List<CompanyDepartmentDTO> CompanyDepartmentList { get; set; }
        public virtual List<CompanyTitleDTO> CompanyTitleList { get; set; }


    }
}
