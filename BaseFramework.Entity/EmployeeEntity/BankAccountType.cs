using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class BankAccountType
    {
        public BankAccountType()
        {
            BankInformations = new HashSet<BankInformation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BankInformation> BankInformations { get; set; }
    }
}
