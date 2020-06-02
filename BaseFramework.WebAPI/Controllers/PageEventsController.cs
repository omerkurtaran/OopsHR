using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Model.ProjectBaseDTO;
using BaseFramework.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/PageEvents")]
    [OOPSModelValidation]
    [Authorize]

    public class PageEventsController : ApiController
    {
        private IPageEventService service;

        public PageEventsController(IPageEventService _service)
        {
            service = _service;
        }

        [Route("GetPageEvent")]
        public HttpResponseMessage Get()
        {
            List<PageEventDTO> pageeventList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, pageeventList);
        }

        [Route("GetPageEventDetail")]
        public HttpResponseMessage Get(int Id)
        {
            PageEventDTO selectedPageEvent = service.getPageEvent(Id);
            if (selectedPageEvent == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + " Id li PageEvent Bulunamadı");
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedPageEvent);
        }

        [Route("Add")]
        public HttpResponseMessage Post(PageEventDTO pageeventDTO)
        {
            try
            {
                PageEventDTO dto = service.newPageEvent(pageeventDTO);
                if (dto != null)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Eklenirken Sorun Oluştu");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Eklenirken Sorun Oluştu");
            }

        }

        [Route("Update")]
        public HttpResponseMessage Put(PageEventDTO pageeventDTO)
        {
            try
            {
                PageEventDTO dto = service.updatePageEvent(pageeventDTO);
                if (dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Güncellenirken Sorun Oluştu");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Güncellenirken Sorun Oluştu");
            }

        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                bool isDeleted = service.deletePageEvent(Id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "PageEvent Silindi");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Silinirken Sorun Oluştu");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "PageEvent Silinirken Sorun Oluştu");
            }
        }
    }
}