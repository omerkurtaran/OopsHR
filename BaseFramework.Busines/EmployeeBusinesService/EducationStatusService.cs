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
   public class EducationStatusService : IEducationStatusService
    {
        private readonly IUnitofWork uow;
        public EducationStatusService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEducationStatus(int educationStatusId)
        {
            try
            {
                var getEducationStatus = uow.GetRepository<EducationStatus>().Get(z => z.Id == educationStatusId);
                uow.GetRepository<EducationStatus>().Delete(getEducationStatus);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EducationStatusDTO> getAll()
        {
            var getEducationStatusList = uow.GetRepository<EducationStatus>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EducationStatusDTO>>(getEducationStatusList);
        }

        public EducationStatusDTO getEducationStatus(int Id)
        {
            var getEducationStatus = uow.GetRepository<EducationStatus>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EducationStatusDTO>(getEducationStatus);
        }

        public EducationStatusDTO newEducationStatus(EducationStatusDTO educationStatus)
        {
            if (!uow.GetRepository<EducationStatus>().GetAll().Any(z => z.Id == educationStatus.Id))
            {
                var adedEducationStatus = MapperFactory.CurrentMapper.Map<EducationStatus>(educationStatus);
                adedEducationStatus = uow.GetRepository<EducationStatus>().Add(adedEducationStatus);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EducationStatusDTO>(adedEducationStatus);
            }
            else
            {
                return null;
            }
        }

        public EducationStatusDTO updateEducationStatus(EducationStatusDTO educationStatus)
        {
            var selectedEducationStatus = uow.GetRepository<EducationStatus>().Get(z => z.Id == educationStatus.Id);
            selectedEducationStatus = MapperFactory.CurrentMapper.Map(educationStatus, selectedEducationStatus);
            uow.GetRepository<EducationStatus>().Update(selectedEducationStatus);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EducationStatusDTO>(selectedEducationStatus);
        }
    }
}
