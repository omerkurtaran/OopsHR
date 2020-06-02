using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface IPageEventService : IServiceBase
    {
        List<PageEventDTO> getAll();
        PageEventDTO newPageEvent(PageEventDTO pageevent);
        PageEventDTO updatePageEvent(PageEventDTO pageevent);
        bool deletePageEvent(int pageeventId);
        PageEventDTO getPageEvent(int Id);
    }
}
