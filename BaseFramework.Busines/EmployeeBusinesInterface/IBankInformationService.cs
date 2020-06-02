using BaseFramework.Core.Business;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesInterface
{
    public interface IBankInformationService : IServiceBase
    {
        List<BankInformationDTO> getAll();
        BankInformationDTO getBankInformation(int Id);
        BankInformationDTO newBankInformation(BankInformationDTO bankInformation);
        BankInformationDTO updateBankInformation(BankInformationDTO bankInformation);
        bool deleteBankInformation(int bankInformationId);
    }
}
