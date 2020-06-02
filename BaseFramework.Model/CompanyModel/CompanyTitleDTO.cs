using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.CompanyModel
{
    public class CompanyTitleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameCompanyTitleRequiredMessage",
        ErrorMessageResourceType = typeof(sysLanguage.CompanyTitleDTOModelValidationMessage))]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessageResourceName = "CompanyIdCompanyTitleRequiredMessage",
             ErrorMessageResourceType = typeof(sysLanguage.CompanyTitleDTOModelValidationMessage))]
        public Nullable<int> CompanyId { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
