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
    public class BankAccountTypeService : IBankAccountTypeService
    {
        private readonly IUnitofWork uow;
        public BankAccountTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteBankAccountType(int bankAccountTypeId)
        {
            try
            {
                var getBankAccountType = uow.GetRepository<BankAccountType>().Get(z => z.Id == bankAccountTypeId);
                uow.GetRepository<BankAccountType>().Delete(getBankAccountType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BankAccountTypeDTO> getAll()
        {
            var getBankAccountTypeList = uow.GetRepository<BankAccountType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<BankAccountTypeDTO>>(getBankAccountTypeList);
        }

        public BankAccountTypeDTO getBankAccountType(int Id)
        {
            var getBankAccountType = uow.GetRepository<BankAccountType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<BankAccountTypeDTO>(getBankAccountType);
        }

        public BankAccountTypeDTO newBankAccountType(BankAccountTypeDTO bankAccountType)
        {
            if (!uow.GetRepository<BankAccountType>().GetAll().Any(z => z.Id == bankAccountType.Id))
            {
                var adedBankAccountType = MapperFactory.CurrentMapper.Map<BankAccountType>(bankAccountType);
                adedBankAccountType = uow.GetRepository<BankAccountType>().Add(adedBankAccountType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<BankAccountTypeDTO>(adedBankAccountType);
            }
            else
            {
                return null;
            }
        }

        public BankAccountTypeDTO updateBankAccountType(BankAccountTypeDTO bankAccountType)
        {
            var selectedBankAccountType = uow.GetRepository<BankAccountType>().Get(z => z.Id == bankAccountType.Id);
            selectedBankAccountType = MapperFactory.CurrentMapper.Map(bankAccountType, selectedBankAccountType);
            uow.GetRepository<BankAccountType>().Update(selectedBankAccountType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<BankAccountTypeDTO>(selectedBankAccountType);

        }
    }
}