using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.EmployeeEntity;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.EmployeeBusinesService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitofWork uow;
        public EmployeeService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteEmployee(int employeeId)
        {
            try
            {
                var getEmployee = uow.GetRepository<Employee>().Get(z => z.Id == employeeId);
                uow.GetRepository<Employee>().Delete(getEmployee);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EmployeeDTO> getCompanyEmployees(int companyId)
        {
            var getEmployeeList = uow.GetRepository<Employee>().GetAll().Where(z => z.CompanyBranchID == companyId).ToList();
            return MapperFactory.CurrentMapper.Map<List<EmployeeDTO>>(getEmployeeList);
        }

        public EmployeeDTO getEmployee(int Id)
        {
            var getEmployee = uow.GetRepository<Employee>()
                    .GetIncludes(a => a.Id == Id,
                                 b => b.AccessType,
                                 c => c.EmployeeDetail,
                                 d => d.ContractType,
                                 e => e.EmployeeOtherInfo,
                                 f => f.ContractType,
                                 g => g.CompanyBranch,
                                 h => h.CompanyTitle,
                                 i => i.CompanyDepartment
                                 );
            return MapperFactory.CurrentMapper.Map<EmployeeDTO>(getEmployee);
        }

        public EmployeeDTO newEmployee(EmployeeDTO employee)
        {
            if (!uow.GetRepository<Employee>().GetAll().Any(z => z.Id == employee.Id))
            {
                var adedEmployee = MapperFactory.CurrentMapper.Map<Employee>(employee);
                adedEmployee = uow.GetRepository<Employee>().Add(adedEmployee);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<EmployeeDTO>(adedEmployee);
            }
            else
            {
                return null;
            }
        }

        public EmployeeDTO updateEmployee(EmployeeDTO employee)
        {
            var selectedEmployee = uow.GetRepository<Employee>().Get(z => z.Id == employee.Id);
            selectedEmployee = MapperFactory.CurrentMapper.Map(employee, selectedEmployee);
            uow.GetRepository<Employee>().Update(selectedEmployee);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<EmployeeDTO>(selectedEmployee);
        }
    }
}
