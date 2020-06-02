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
    public class PermitTypeService : IPermitTypeService
    {
        private readonly IUnitofWork uow;
        public PermitTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deletePermitType(int permitTypeId)
        {
            try
            {
                var getPermitType = uow.GetRepository<PermitType>().Get(z => z.Id == permitTypeId);
                uow.GetRepository<PermitType>().Delete(getPermitType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PermitTypeDTO> getAll()
        {
            var getPermitTypeList = uow.GetRepository<PermitType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<PermitTypeDTO>>(getPermitTypeList);
        }

        public PermitTypeDTO getPermitType(int Id)
        {
            var getPermitType = uow.GetRepository<PermitType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<PermitTypeDTO>(getPermitType);
        }

        public PermitTypeDTO newPermitType(PermitTypeDTO permitType)
        {
            if (!uow.GetRepository<PermitType>().GetAll().Any(z => z.Id == permitType.Id))
            {
                var adedPermitType = MapperFactory.CurrentMapper.Map<PermitType>(permitType);
                adedPermitType = uow.GetRepository<PermitType>().Add(adedPermitType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<PermitTypeDTO>(adedPermitType);
            }
            else
            {
                return null;
            }
        }

        public PermitTypeDTO updatePermitType(PermitTypeDTO permitType)
        {
            var selectedPermitType = uow.GetRepository<PermitType>().Get(z => z.Id == permitType.Id);
            selectedPermitType = MapperFactory.CurrentMapper.Map(permitType, selectedPermitType);
            uow.GetRepository<PermitType>().Update(selectedPermitType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<PermitTypeDTO>(selectedPermitType);
        }
    }
}