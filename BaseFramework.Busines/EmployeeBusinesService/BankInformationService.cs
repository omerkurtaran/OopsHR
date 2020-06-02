using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesService
{
    public class BankInformationService : IBankInformationService
    {
        private readonly IUnitofWork uow;
        public BankInformationService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteBankInformation(int bankInformationId)
        {
            try
            {
                var getBankInformation = uow.GetRepository<BankInformation>().Get(z => z.Id == bankInformationId);
                uow.GetRepository<BankInformation>().Delete(getBankInformation);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BankInformationDTO> getAll()
        {
            var getBankInformationList = uow.GetRepository<BankInformation>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<BankInformationDTO>>(getBankInformationList);
        }

        public BankInformationDTO getBankInformation(int Id)
        {
            var getBankInformation = uow.GetRepository<BankInformation>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<BankInformationDTO>(getBankInformation);
        }

        public BankInformationDTO newBankInformation(BankInformationDTO bankInformation)
        {
            if (!uow.GetRepository<BankInformation>().GetAll().Any(z => z.Id == bankInformation.Id))
            {
                var adedBankInformation = MapperFactory.CurrentMapper.Map<BankInformation>(bankInformation);
                adedBankInformation = uow.GetRepository<BankInformation>().Add(adedBankInformation);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<BankInformationDTO>(adedBankInformation);
            }
            else
            {
                return null;
            }
        }

        public BankInformationDTO updateBankInformation(BankInformationDTO bankInformation)
        {
            var selectedBankInformation = uow.GetRepository<BankInformation>().Get(z => z.Id == bankInformation.Id);
            selectedBankInformation = MapperFactory.CurrentMapper.Map(bankInformation, selectedBankInformation);
            uow.GetRepository<BankInformation>().Update(selectedBankInformation);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<BankInformationDTO>(selectedBankInformation);
        }
    }
}