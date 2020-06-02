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
    public class CompanyTitleService : ICompanyTitleService
    {
        private readonly IUnitofWork uow;
        public CompanyTitleService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteTitle(int titleId)
        {
            try
            {
                var getTitle = uow.GetRepository<CompanyTitle>().Get(z => z.Id == titleId);
                uow.GetRepository<CompanyTitle>().Delete(getTitle);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CompanyTitleDTO FindwithTitle(string Name)
        {
            var getTitle = uow.GetRepository<CompanyTitle>().Get(z => z.Name == Name);
            return MapperFactory.CurrentMapper.Map<CompanyTitleDTO>(getTitle);
        }

        public List<CompanyTitleDTO> GetAll()
        {
            var getTitleList = uow.GetRepository<CompanyTitle>().GetAll().ToList();
            return MapperFactory.CurrentMapper.Map<List<CompanyTitleDTO>>(getTitleList);
        }

        public List<CompanyTitleDTO> getSelectByCompanyId(int companyId)
        {
            var getCompanyTitleListhwithCompanyId = uow.GetRepository<CompanyTitle>().Get(z => z.CompanyId == companyId);
            return MapperFactory.CurrentMapper.Map<List<CompanyTitleDTO>>(getCompanyTitleListhwithCompanyId);
        }

        public CompanyTitleDTO getTitle(int Id)
        {
            var getTitle = uow.GetRepository<CompanyTitle>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<CompanyTitleDTO>(getTitle);
        }

        public CompanyTitleDTO newTitle(CompanyTitleDTO title)
        {
            if (!uow.GetRepository<CompanyTitle>().GetAll().Any(z => z.Name == title.Name))
            {
                var addedTitle = MapperFactory.CurrentMapper.Map<CompanyTitle>(title);
                addedTitle = uow.GetRepository<CompanyTitle>().Add(addedTitle);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<CompanyTitleDTO>(addedTitle);
            }
            else
            {
                return null;
            }
        }

        public CompanyTitleDTO updateTitle(CompanyTitleDTO title)
        {

            var selectedTitle = uow.GetRepository<CompanyTitle>().Get(z => z.Id == title.Id);
            selectedTitle = MapperFactory.CurrentMapper.Map(title, selectedTitle);
            uow.GetRepository<CompanyTitle>().Update(selectedTitle);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<CompanyTitleDTO>(selectedTitle);
        }

       
    }
}
