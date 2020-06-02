using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class RoleEventDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "RoleIdRoleEventRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.RoleEventModelValidationMessage))]
        public int RoleId { get; set; }

        [Required(ErrorMessageResourceName = "PageEventIdRoleEventRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.RoleEventModelValidationMessage))]
        public int PageEventId { get; set; }
        public PageEventDTO PageEvent { get; set; }
        public RoleDTO Role { get; set; }
    }
}
