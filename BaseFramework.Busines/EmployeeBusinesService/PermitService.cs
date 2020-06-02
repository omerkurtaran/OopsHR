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
    public class PermitService : IPermitService
    {
        private readonly IUnitofWork uow;
        public PermitService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deletePermit(int permitId)
        {
            try
            {
                var getPermit = uow.GetRepository<Permit>().Get(z => z.Id == permitId);
                uow.GetRepository<Permit>().Delete(getPermit);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PermitDTO> getAll()
        {
            var getPermitList = uow.GetRepository<Permit>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<PermitDTO>>(getPermitList);
        }

        public PermitDTO getPermit(int Id)
        {
            var getPermit = uow.GetRepository<Permit>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<PermitDTO>(getPermit);
        }

        public PermitDTO newPermit(PermitDTO permit)
        {
            if (!uow.GetRepository<Permit>().GetAll().Any(z => z.Id == permit.Id))
            {
                var adedPermit = MapperFactory.CurrentMapper.Map<Permit>(permit);
                adedPermit = uow.GetRepository<Permit>().Add(adedPermit);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<PermitDTO>(adedPermit);
            }
            else
            {
                return null;
            }
        }

        public PermitDTO updatePermit(PermitDTO permit)
        {
            var selectedPermit = uow.GetRepository<Permit>().Get(z => z.Id == permit.Id);
            selectedPermit = MapperFactory.CurrentMapper.Map(permit, selectedPermit);
            uow.GetRepository<Permit>().Update(selectedPermit);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<PermitDTO>(selectedPermit);
        }
    }
}