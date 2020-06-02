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
    public class PageEventService : IPageEventService
    {
        private readonly IUnitofWork uow;
        public PageEventService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deletePageEvent(int pageeventId)
        {
            try
            {
                var getPageEvent = uow.GetRepository<PageEvent>().Get(z => z.Id == pageeventId);
                uow.GetRepository<PageEvent>().Delete(getPageEvent);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PageEventDTO> getAll()
        {
            var getPageEventList = uow.GetRepository<PageEvent>().Get(null, null, null).ToList();
            return MapperFactory.CurrentMapper.Map<List<PageEventDTO>>(getPageEventList);
        }

        public PageEventDTO getPageEvent(int Id)
        {
            var getPageEvent = uow.GetRepository<PageEvent>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<PageEventDTO>(getPageEvent);
        }

        public PageEventDTO newPageEvent(PageEventDTO pageevent)
        {
            if (!uow.GetRepository<PageEvent>().GetAll().Any(z => z.EventName == pageevent.EventName))
            {
                var adedPageEvent = MapperFactory.CurrentMapper.Map<PageEvent>(pageevent);
                adedPageEvent = uow.GetRepository<PageEvent>().Add(adedPageEvent);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<PageEventDTO>(adedPageEvent);
            }
            else
            {
                return null;
            }
        }

        public PageEventDTO updatePageEvent(PageEventDTO pageevent)
        {
            var selectedPageEvent = uow.GetRepository<PageEvent>().Get(z => z.Id == pageevent.Id);
            selectedPageEvent = MapperFactory.CurrentMapper.Map(pageevent, selectedPageEvent);
            uow.GetRepository<PageEvent>().Update(selectedPageEvent);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<PageEventDTO>(selectedPageEvent);
        }



    }
}