using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Model.EmployeeModelDTO;
using BaseFramework.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/ RequestForVisa")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class RequestForVisaController : ApiController
    {
        private IRequestForVisaService service;
        public RequestForVisaController(IRequestForVisaService _service)
        {
            service = _service;
        }

        [Route("RequestForVisaList")]
        public HttpResponseMessage Get()
        {
            List<RequestForVisaDTO> RequestForVisalist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, RequestForVisalist);
        }

        [Route("RequestForVisaDetail")]
        public HttpResponseMessage Get(int Id)
        {
            RequestForVisaDTO selectedTitle = service.getRequestForVisa(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(RequestForVisaDTO RequestForVisaDTO)
        {

            RequestForVisaDTO dto = service.newRequestForVisa(RequestForVisaDTO);
            if (dto != null)
            {
                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.add_title);
            }


        }

        [Route("Update")]
        public HttpResponseMessage Put(RequestForVisaDTO RequestForVisaDTO)
        {
            RequestForVisaDTO dto = service.updateRequestForVisa(RequestForVisaDTO);
            if (dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.update_title);
            }
        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            bool isDeleted = service.deleteRequestForVisa(Id);
            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.CompanyTitlesControllerStrings.delete_title);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.delete_titleError);
            }

        }
    }
}
