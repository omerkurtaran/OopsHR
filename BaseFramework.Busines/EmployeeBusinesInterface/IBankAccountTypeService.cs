using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IBankAccountTypeService : IServiceBase
    {
        List<BankAccountTypeDTO> getAll();
        BankAccountTypeDTO getBankAccountType(int Id);
        BankAccountTypeDTO newBankAccountType(BankAccountTypeDTO bankAccountType);
        BankAccountTypeDTO updateBankAccountType(BankAccountTypeDTO bankAccountType);
        bool deleteBankAccountType(int bankAccountTypeId);
    }
}
