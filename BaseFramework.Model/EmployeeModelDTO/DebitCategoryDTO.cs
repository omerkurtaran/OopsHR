using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Model.EmployeeModelDTO
{
    public class DebitCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DebitDTO> Debits { get; set; }
    }
}
