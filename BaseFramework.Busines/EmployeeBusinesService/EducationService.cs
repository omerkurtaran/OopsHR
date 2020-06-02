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
    public class EducationService : IEducationService
    {
        private readonly IUnitofWork uow;
        public EducationService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEducation(int EducationId)
        {
            try
            {
                var getEducation = uow.GetRepository<Education>().Get(z => z.Id ==EducationId);
                uow.GetRepository<Education>().Delete(getEducation);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EducationDTO> getAll()
        {
            var getEducationList = uow.GetRepository<Education>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EducationDTO>>(getEducationList);
        }

        public EducationDTO getEducation(int Id)
        {
            var getEducation = uow.GetRepository<Education>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EducationDTO>(getEducation);
        }

        public EducationDTO newEducation(EducationDTO Education)
        {
            if (!uow.GetRepository<Education>().GetAll().Any(z => z.Id ==Education.Id))
            {
                var adedEducation = MapperFactory.CurrentMapper.Map<Education>(Education);
                adedEducation = uow.GetRepository<Education>().Add(adedEducation);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EducationDTO>(adedEducation);
            }
            else
            {
                return null;
            }
        }

        public EducationDTO updateEducation(EducationDTO Education)
        {
            var selectedEducation = uow.GetRepository<Education>().Get(z => z.Id ==Education.Id);
            selectedEducation = MapperFactory.CurrentMapper.Map(Education, selectedEducation);
            uow.GetRepository<Education>().Update(selectedEducation);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EducationDTO>(selectedEducation);
        }
    }
}
