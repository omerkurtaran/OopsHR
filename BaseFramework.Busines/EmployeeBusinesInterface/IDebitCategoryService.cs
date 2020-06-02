using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IDebitCategoryService : IServiceBase
    {
        List<DebitCategoryDTO> getAll();
        DebitCategoryDTO getDebitCategory(int Id);
        DebitCategoryDTO newDebitCategory(DebitCategoryDTO debitCategory);
        DebitCategoryDTO updateDebitCategory(DebitCategoryDTO debitCategory);
        bool deleteDebitCategory(int debitCategoryId);
    }
}
