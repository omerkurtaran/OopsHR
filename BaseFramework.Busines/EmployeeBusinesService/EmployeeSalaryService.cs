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
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IUnitofWork uow;
        public EmployeeSalaryService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEmployeeSalary(int employeeSalaryId)
        {
            try
            {
                var getEmployeeSalary = uow.GetRepository<EmployeeSalary>().Get(z => z.Id == employeeSalaryId);
                uow.GetRepository<EmployeeSalary>().Delete(getEmployeeSalary);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeSalaryDTO> getAll()
        {
            var getEmployeeSalaryList = uow.GetRepository<EmployeeSalary>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<EmployeeSalaryDTO>>(getEmployeeSalaryList);
        }

        public EmployeeSalaryDTO getEmployeeSalary(int Id)
        {
            var getEmployeeSalary = uow.GetRepository<EmployeeSalary>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<EmployeeSalaryDTO>(getEmployeeSalary);
        }

        public EmployeeSalaryDTO newEmployeeSalary(EmployeeSalaryDTO employeeSalary)
        {
            if (!uow.GetRepository<EmployeeSalary>().GetAll().Any(z => z.Id == employeeSalary.Id))
            {
                var adedEmployeeSalary = MapperFactory.CurrentMapper.Map<EmployeeSalary>(employeeSalary);
                adedEmployeeSalary = uow.GetRepository<EmployeeSalary>().Add(adedEmployeeSalary);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EmployeeSalaryDTO>(adedEmployeeSalary);
            }
            else
            {
                return null;
            }
        }

        public EmployeeSalaryDTO updateEmployeeSalary(EmployeeSalaryDTO employeeSalary)
        {
            var selectedEmployeeSalary = uow.GetRepository<EmployeeSalary>().Get(z => z.Id == employeeSalary.Id);
            selectedEmployeeSalary = MapperFactory.CurrentMapper.Map(employeeSalary, selectedEmployeeSalary);
            uow.GetRepository<EmployeeSalary>().Update(selectedEmployeeSalary);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EmployeeSalaryDTO>(selectedEmployeeSalary);
        }
    }
}
