using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface IPageService : IServiceBase
    {
        List<PageDTO> getAll();
        PageDTO newPage(PageDTO page);
        PageDTO updatePage(PageDTO page);
        bool deletePage(int pageId);
        PageDTO getPage(int Id);
    }
}
