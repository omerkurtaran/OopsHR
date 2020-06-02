using System.Collections.Generic;

namespace BaseFramework.MappingTest.EmployeeEntity
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