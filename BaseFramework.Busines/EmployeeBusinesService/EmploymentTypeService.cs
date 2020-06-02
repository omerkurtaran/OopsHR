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
    public class EmploymentTypeService : IEmploymentTypeService
    {
        private readonly IUnitofWork uow;
        public EmploymentTypeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEmploymentType(int employmentTypeId)
        {
            try
            {
                var getEmploymentType = uow.GetRepository<EmploymentType>().Get(z => z.Id == employmentTypeId);
                uow.GetRepository<EmploymentType>().Delete(getEmploymentType);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmploymentTypeDTO> getAll()
        {
            var getEmploymentTypeList = uow.GetRepository<EmploymentType>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EmploymentTypeDTO>>(getEmploymentTypeList);
        }

        public EmploymentTypeDTO getEmploymentType(int Id)
        {
            var getEmploymentType = uow.GetRepository<EmploymentType>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EmploymentTypeDTO>(getEmploymentType);
        }

        public EmploymentTypeDTO newEmploymentType(EmploymentTypeDTO employmentType)
        {
            if (!uow.GetRepository<EmploymentType>().GetAll().Any(z => z.Id == employmentType.Id))
            {
                var adedEmploymentType = MapperFactory.CurrentMapper.Map<EmploymentType>(employmentType);
                adedEmploymentType = uow.GetRepository<EmploymentType>().Add(adedEmploymentType);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EmploymentTypeDTO>(adedEmploymentType);
            }
            else
            {
                return null;
            }
        }

        public EmploymentTypeDTO updateEmploymentType(EmploymentTypeDTO employmentType)
        {
            var selectedEmploymentType = uow.GetRepository<EmploymentType>().Get(z => z.Id == employmentType.Id);
            selectedEmploymentType = MapperFactory.CurrentMapper.Map(employmentType, selectedEmploymentType);
            uow.GetRepository<EmploymentType>().Update(selectedEmploymentType);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EmploymentTypeDTO>(selectedEmploymentType);
        }
    }
}
