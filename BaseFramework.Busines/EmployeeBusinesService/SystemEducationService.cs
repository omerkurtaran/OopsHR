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
    public class SystemEducationService : ISystemEducationService
    {
        private readonly IUnitofWork uow;
        public SystemEducationService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteSystemEducation(int systemEducationId)
        {
            try
            {
                var getSystemEducation = uow.GetRepository<SystemEducation>().Get(z => z.Id == systemEducationId);
                uow.GetRepository<SystemEducation>().Delete(getSystemEducation);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<SystemEducationDTO> getAll()
        {
            var getSystemEducationList = uow.GetRepository<SystemEducation>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<SystemEducationDTO>>(getSystemEducationList);
        }

        public SystemEducationDTO getSystemEducation(int Id)
        {
            var getSystemEducation = uow.GetRepository<SystemEducation>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<SystemEducationDTO>(getSystemEducation);
        }

        public SystemEducationDTO newSystemEducation(SystemEducationDTO systemEducation)
        {
            if (!uow.GetRepository<SystemEducation>().GetAll().Any(z => z.Id == systemEducation.Id))
            {
                var adedSystemEducation = MapperFactory.CurrentMapper.Map<SystemEducation>(systemEducation);
                adedSystemEducation = uow.GetRepository<SystemEducation>().Add(adedSystemEducation);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<SystemEducationDTO>(adedSystemEducation);
            }
            else
            {
                return null;
            }
        }

        public SystemEducationDTO updateSystemEducation(SystemEducationDTO systemEducation)
        {
            var selectedSystemEducation = uow.GetRepository<SystemEducation>().Get(z => z.Id == systemEducation.Id);
            selectedSystemEducation = MapperFactory.CurrentMapper.Map(systemEducation, selectedSystemEducation);
            uow.GetRepository<SystemEducation>().Update(selectedSystemEducation);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<SystemEducationDTO>(selectedSystemEducation);
        }
    }
}
