using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{
    public class PageService : IPageService
    {
        private readonly IUnitofWork uow;
        public PageService(IUnitofWork uow)
        {
            this.uow = uow;
        }


        public bool deletePage(int pageId)
        {
            try
            {
                var getPage = uow.GetRepository<Page>().Get(z => z.Id == pageId);
                uow.GetRepository<Page>().Delete(getPage);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PageDTO> getAll()
        {
            var getPageList = uow.GetRepository<Page>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<PageDTO>>(getPageList);
        }

        public PageDTO getPage(int Id)
        {
            var getPage = uow.GetRepository<Page>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<PageDTO>(getPage);
        }

        public PageDTO newPage(PageDTO page)
        {
            if (!uow.GetRepository<Page>().GetAll().Any(z => z.Name == page.Name))
            {
                var adedPage = MapperFactory.CurrentMapper.Map<Page>(page);
                adedPage = uow.GetRepository<Page>().Add(adedPage);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<PageDTO>(adedPage);
            }
            else
            {
                return null;
            }
        }

        public PageDTO updatePage(PageDTO page)
        {
            var selectedPage = uow.GetRepository<Page>().Get(z => z.Id == page.Id);
            selectedPage = MapperFactory.CurrentMapper.Map(page, selectedPage);
            uow.GetRepository<Page>().Update(selectedPage);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<PageDTO>(selectedPage);
        }
    }
}