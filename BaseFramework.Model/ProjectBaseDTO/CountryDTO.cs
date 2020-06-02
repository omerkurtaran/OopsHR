using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "CountryNameCountryRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.CountryModelValidationMessage))]
        public string CountryName { get; set; }
        public string LangCode { get; set; }
        public string Code { get; set; }

        public List<CityDTO> Cities { get; set; }
    }
}
