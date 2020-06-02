using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IDebitService : IServiceBase
    {
        List<DebitDTO> getAll();
        DebitDTO getDebit(int Id);
        DebitDTO newDebit(DebitDTO Debit);
        DebitDTO updateDebit(DebitDTO Debit);
        bool deleteDebit(int Id);
    }
}