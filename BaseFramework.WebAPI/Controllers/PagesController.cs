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
    [RoutePrefix("api/Pages")]
    [OOPSModelValidation]
    [Authorize]
    public class PagesController : ApiController
    {
        private IPageService service;

        public PagesController(IPageService _service)
        {
            service = _service;
        }

        [Route("GetPage")]
        public HttpResponseMessage Get()
        {
            List<PageDTO> pageList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, pageList);
        }

        [Route("GetPageDetail")]
        public HttpResponseMessage Get(int Id)
        {
            PageDTO selectedPage = service.getPage(Id);
            if (selectedPage == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + " Id li Page Bulunamadı");
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedPage);
        }

        [Route("Add")]
        public HttpResponseMessage Post(PageDTO pageDTO)
        {
            try
            {
                PageDTO dto = service.newPage(pageDTO);
                if (dto != null)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Eklenirken Sorun Oluştu");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Eklenirken Sorun Oluştu");
            }

        }

        [Route("Update")]
        public HttpResponseMessage Put(PageDTO pageDTO)
        {
            try
            {
                PageDTO dto = service.updatePage(pageDTO);
                if (dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Güncellenirken Sorun Oluştu");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Güncellenirken Sorun Oluştu");
            }

        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                bool isDeleted = service.deletePage(Id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Page Silindi");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Silinirken Sorun Oluştu");
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, "Page Silinirken Sorun Oluştu");
            }
        }

    }
}