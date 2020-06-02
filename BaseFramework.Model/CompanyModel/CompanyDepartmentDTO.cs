using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.CompanyModel
{
    public class CompanyDepartmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameCompanyDepartmentRequiredMessage",
        ErrorMessageResourceType = typeof(sysLanguage.CompanyDepartmentDTOModelValidationMessage))]
        public string Name { get; set; }

        public Nullable<int> CompanyId { get; set; }
        public virtual CompanyDTO Company { get; set; }

        public List<CompanyDepartmentDTO> CompanyDepartments { get; set; }
        public virtual CompanyDepartmentDTO CompanyDepartment1 { get; set; }
    }
}
