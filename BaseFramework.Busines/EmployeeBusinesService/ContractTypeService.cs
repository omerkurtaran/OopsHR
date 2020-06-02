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
    public class ContractTypeService : IContractTypeService
    {
        private readonly IUnitofWork uow;
        public ContractTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteContractType(int contractTypeId)
        {
            try
            {
                var getContractType = uow.GetRepository<ContractType>().Get(z => z.Id == contractTypeId);
                uow.GetRepository<ContractType>().Delete(getContractType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ContractTypeDTO> getAll()
        {
            var getContractTypeList = uow.GetRepository<ContractType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<ContractTypeDTO>>(getContractTypeList);
        }

        public ContractTypeDTO getContractType(int Id)
        {
            var getContractType = uow.GetRepository<ContractType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<ContractTypeDTO>(getContractType);
        }

        public ContractTypeDTO newContractType(ContractTypeDTO contractType)
        {
            if (!uow.GetRepository<ContractType>().GetAll().Any(z => z.Id == contractType.Id))
            {
                var adedContractType = MapperFactory.CurrentMapper.Map<ContractType>(contractType);
                adedContractType = uow.GetRepository<ContractType>().Add(adedContractType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<ContractTypeDTO>(adedContractType);
            }
            else
            {
                return null;
            }
        }

        public ContractTypeDTO updateContractType(ContractTypeDTO contractType)
        {
            var selectedContractType = uow.GetRepository<ContractType>().Get(z => z.Id == contractType.Id);
            selectedContractType = MapperFactory.CurrentMapper.Map(contractType, selectedContractType);
            uow.GetRepository<ContractType>().Update(selectedContractType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<ContractTypeDTO>(selectedContractType);
        }
    }
}
