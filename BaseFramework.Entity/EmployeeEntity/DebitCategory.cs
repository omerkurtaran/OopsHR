using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Entity.EmployeeEntity
{
    public class DebitCategory
    {
        public DebitCategory()
        {
            Debts = new HashSet<Debit>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Debit> Debts { get; set; }
    }
}
