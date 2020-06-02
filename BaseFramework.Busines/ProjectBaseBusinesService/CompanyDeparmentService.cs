using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{
    public class CompanyDeparmentService : ICompanyDeparmantService
    {
        private readonly IUnitofWork uow;
        public CompanyDeparmentService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteDepartmant(int DepartmantId)
        {
            try
            {
                var getDepartment = uow.GetRepository<CompanyDepartment>().Get(z => z.Id == DepartmantId);
                uow.GetRepository<CompanyDepartment>().Delete(getDepartment);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CompanyDepartmentDTO> getAll()
        {
            var getDepartmentList = uow.GetRepository<CompanyDepartment>().Get(null, null, null).ToList();

            return MapperFactory.CurrentMapper.Map<List<CompanyDepartmentDTO>>(getDepartmentList);
        }

        public CompanyDepartmentDTO getDepartmant(int Id)
        {
            var getDepartment = uow.GetRepository<CompanyDepartment>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CompanyDepartmentDTO>(getDepartment);
        }

        public CompanyDepartmentDTO newDepartmant(CompanyDepartmentDTO companyDeparment)
        {
            if (!uow.GetRepository<CompanyDepartment>().GetAll().Any(z => z.Name == companyDeparment.Name))
            {
                var adedCompanyDepartment = MapperFactory.CurrentMapper.Map<CompanyDepartment>(companyDeparment);
                adedCompanyDepartment = uow.GetRepository<CompanyDepartment>().Add(adedCompanyDepartment);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CompanyDepartmentDTO>(adedCompanyDepartment);
            }
            else
            {
                return null;
            }
        }

        public CompanyDepartmentDTO updateDepartmant(CompanyDepartmentDTO companyDeparment)
        {
            var selectedDepartment = uow.GetRepository<CompanyDepartment>().Get(z => z.Id == companyDeparment.Id);
            selectedDepartment = MapperFactory.CurrentMapper.Map(companyDeparment, selectedDepartment);
            uow.GetRepository<CompanyDepartment>().Update(selectedDepartment);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CompanyDepartmentDTO>(selectedDepartment);
        }
    }
}
