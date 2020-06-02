using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.ProjectBaseDTO
{
    public class CityDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "NameCityRequiredMessage",
            ErrorMessageResourceType = typeof(sysLanguage.CityModelValidationMessage))]
        public string Name { get; set; }
        public string Code { get; set; }

        [Required(ErrorMessageResourceName = "CountryIdCityRequiredMessage",
    ErrorMessageResourceType = typeof(sysLanguage.CityModelValidationMessage))]
        public Nullable<int> CountryId { get; set; }
        public CountryDTO Country { get; set; }

        public List<DistrictDTO> Districts { get; set; }
    }
}
