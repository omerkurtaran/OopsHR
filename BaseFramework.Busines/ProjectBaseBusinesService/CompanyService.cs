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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitofWork uow;
        public CompanyService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteCompany(int CompanyId)
        {
            try
            {
                var getCompany = uow.GetRepository<Company>().Get(z => z.Id == CompanyId);
                uow.GetRepository<Company>().Delete(getCompany);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CompanyDTO> getAll()
        {
            var getCompanyList = uow.GetRepository<Company>().Get(null,null,null).ToList();

            return MapperFactory.CurrentMapper.Map<List<CompanyDTO>>(getCompanyList);
            
        }

        public CompanyDTO getCompany(int Id)
        {
            var getCompany = uow.GetRepository<Company>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CompanyDTO>(getCompany);
        }

        public CompanyDTO newCompany(CompanyDTO Company)
        {
            if (!uow.GetRepository<Company>().GetAll().Any(z => z.CompanyName == Company.CompanyName))
            {
                var adedCompany = MapperFactory.CurrentMapper.Map<Company>(Company);
                adedCompany = uow.GetRepository<Company>().Add(adedCompany);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CompanyDTO>(adedCompany);
            }
            else
            {
                return null;
            }
        }

        public CompanyDTO updateCompany(CompanyDTO Company)
        {
            var selectedCompany = uow.GetRepository<Company>().Get(z => z.Id == Company.Id);
            selectedCompany = MapperFactory.CurrentMapper.Map(Company, selectedCompany);
            uow.GetRepository<Company>().Update(selectedCompany);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CompanyDTO>(selectedCompany);
        }
    }

}
