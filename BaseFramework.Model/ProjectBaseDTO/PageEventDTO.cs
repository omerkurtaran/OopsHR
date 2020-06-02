using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class PageEventDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "EventNamePageEventRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.PageEventModelValidationMessage))]
        public string EventName { get; set; }
        public bool IsActive { get; set; }

        public int PageId { get; set; }
        public PageDTO Page { get; set; }

    }
}
