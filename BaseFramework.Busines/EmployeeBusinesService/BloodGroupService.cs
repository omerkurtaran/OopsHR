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
    public class BloodGroupService : IBloodGroupService
    {
        private readonly IUnitofWork uow;
        public BloodGroupService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteBloodGroup(int bloodGroupId)
        {
            try
            {
                var getBloodGroup = uow.GetRepository<BloodGroup>().Get(z => z.Id == bloodGroupId);
                uow.GetRepository<BloodGroup>().Delete(getBloodGroup);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BloodGroupDTO> getAll()
        {
            var getBloodGroupList = uow.GetRepository<BloodGroup>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<BloodGroupDTO>>(getBloodGroupList);
        }

        public BloodGroupDTO getBloodGroup(int Id)
        {
            var getBloodGroup = uow.GetRepository<BloodGroup>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<BloodGroupDTO>(getBloodGroup);
        }

        public BloodGroupDTO newBloodGroup(BloodGroupDTO bloodGroup)
        {
            if (!uow.GetRepository<BloodGroup>().GetAll().Any(z => z.Id == bloodGroup.Id))
            {
                var adedBloodGroup = MapperFactory.CurrentMapper.Map<BloodGroup>(bloodGroup);
                adedBloodGroup = uow.GetRepository<BloodGroup>().Add(adedBloodGroup);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<BloodGroupDTO>(adedBloodGroup);
            }
            else
            {
                return null;
            }
        }

        public BloodGroupDTO updateBloodGroup(BloodGroupDTO bloodGroup)
        {
            var selectedBloodGroup = uow.GetRepository<BloodGroup>().Get(z => z.Id == bloodGroup.Id);
            selectedBloodGroup = MapperFactory.CurrentMapper.Map(bloodGroup, selectedBloodGroup);
            uow.GetRepository<BloodGroup>().Update(selectedBloodGroup);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<BloodGroupDTO>(selectedBloodGroup);
        }
    }
}
