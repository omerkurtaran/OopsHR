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
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IUnitofWork uow;
        public EducationLevelService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEducationLevel(int educationLevelId)
        {
            try
            {
                var getEducationLevel = uow.GetRepository<EducationLevel>().Get(z => z.Id == educationLevelId);
                uow.GetRepository<EducationLevel>().Delete(getEducationLevel);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EducationLevelDTO> getAll()
        {
            var getEducationLevelList = uow.GetRepository<EducationLevel>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EducationLevelDTO>>(getEducationLevelList);
        }

        public EducationLevelDTO getEducationLevel(int Id)
        {
            var getEducationLevel = uow.GetRepository<EducationLevel>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EducationLevelDTO>(getEducationLevel);
        }

        public EducationLevelDTO newEducationLevel(EducationLevelDTO educationLevel)
        {
            if (!uow.GetRepository<EducationLevel>().GetAll().Any(z => z.Id == educationLevel.Id))
            {
                var adedEducationLevel = MapperFactory.CurrentMapper.Map<EducationLevel>(educationLevel);
                adedEducationLevel = uow.GetRepository<EducationLevel>().Add(adedEducationLevel);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EducationLevelDTO>(adedEducationLevel);
            }
            else
            {
                return null;
            }
        }

        public EducationLevelDTO updateEducationLevel(EducationLevelDTO educationLevel)
        {
            var selectedEducationLevel = uow.GetRepository<EducationLevel>().Get(z => z.Id == educationLevel.Id);
            selectedEducationLevel = MapperFactory.CurrentMapper.Map(educationLevel, selectedEducationLevel);
            uow.GetRepository<EducationLevel>().Update(selectedEducationLevel);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EducationLevelDTO>(selectedEducationLevel);
        }
    }
}
