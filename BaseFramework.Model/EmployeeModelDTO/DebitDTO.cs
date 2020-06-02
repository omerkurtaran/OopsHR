using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class DebitDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "DebitCategoryDebitRequiredMessage",
         ErrorMessageResourceType = typeof(sysLanguage.DebitModelValidationMessage))]
       // public string DebitCategory { get; set; }
        public int SerialNumber { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Description { get; set; }

        public Nullable<int> DebitCategoryId { get; set; }
        public virtual DebitCategoryDTO DebitCategory { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
