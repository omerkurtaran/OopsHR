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
    public class EducationsTypeService : IEducationsTypeService
    {
        private readonly IUnitofWork uow;
        public EducationsTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEducationsType(int educationsTypeId)
        {
            try
            {
                var getEducationsType = uow.GetRepository<EducationsType>().Get(z => z.Id == educationsTypeId);
                uow.GetRepository<EducationsType>().Delete(getEducationsType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EducationsTypeDTO> getAll()
        {
            var getEducationsTypeList = uow.GetRepository<EducationsType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EducationsTypeDTO>>(getEducationsTypeList);
        }

        public EducationsTypeDTO getEducationsType(int Id)
        {
            var getEducationsType = uow.GetRepository<EducationsType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EducationsTypeDTO>(getEducationsType);
        }

        public EducationsTypeDTO newEducationsType(EducationsTypeDTO educationsType)
        {
            if (!uow.GetRepository<EducationsType>().GetAll().Any(z => z.Id == educationsType.Id))
            {
                var adedEducationsType = MapperFactory.CurrentMapper.Map<EducationsType>(educationsType);
                adedEducationsType = uow.GetRepository<EducationsType>().Add(adedEducationsType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EducationsTypeDTO>(adedEducationsType);
            }
            else
            {
                return null;
            }
        }

        public EducationsTypeDTO updateEducationsType(EducationsTypeDTO educationsType)
        {
            var selectedEducationsType = uow.GetRepository<EducationsType>().Get(z => z.Id == educationsType.Id);
            selectedEducationsType = MapperFactory.CurrentMapper.Map(educationsType, selectedEducationsType);
            uow.GetRepository<EducationsType>().Update(selectedEducationsType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EducationsTypeDTO>(selectedEducationsType);
        }
    }
}
