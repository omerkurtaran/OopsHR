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
    public class AccessTypeService : IAccessTypeService
    {
        private readonly IUnitofWork uow;
        public AccessTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteAccessType(int accessTypeId)
        {
            try
            {
                var getAccessType = uow.GetRepository<AccessType>().Get(z => z.Id == accessTypeId);
                uow.GetRepository<AccessType>().Delete(getAccessType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<AccessTypeDTO> getAll()
        {
            var getAccessTypeList = uow.GetRepository<AccessType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<AccessTypeDTO>>(getAccessTypeList);
        }

        public AccessTypeDTO getAccessType(int Id)
        {
            var getAccessType = uow.GetRepository<AccessType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<AccessTypeDTO>(getAccessType);
        }

        public AccessTypeDTO newAccessType(AccessTypeDTO accessType)
        {
            if (!uow.GetRepository<AccessType>().GetAll().Any(z => z.Id == accessType.Id))
            {
                var adedAccessType = MapperFactory.CurrentMapper.Map<AccessType>(accessType);
                adedAccessType = uow.GetRepository<AccessType>().Add(adedAccessType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<AccessTypeDTO>(adedAccessType);
            }
            else
            {
                return null;
            }
        }

        public AccessTypeDTO updateAccessType(AccessTypeDTO accessType)
        {
            var selectedAccessType = uow.GetRepository<AccessType>().Get(z => z.Id == accessType.Id);
            selectedAccessType = MapperFactory.CurrentMapper.Map(accessType, selectedAccessType);
            uow.GetRepository<AccessType>().Update(selectedAccessType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<AccessTypeDTO>(selectedAccessType);
        }
    }
}
