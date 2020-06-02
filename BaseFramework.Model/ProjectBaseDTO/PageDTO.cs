using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class PageDTO
    {
        public int Id { get; set; }
        public int SubPageId { get; set; }

        [Required(ErrorMessageResourceName = "NamePageRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.PageModelValidationMessage))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "DescriptionPageRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.PageModelValidationMessage))]
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public List<RoleDTO> RoleList { get; set; }
        public List<PageEventDTO> EventList { get; set; }
    }
}
