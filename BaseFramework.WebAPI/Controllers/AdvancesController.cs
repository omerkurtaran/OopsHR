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
    [RoutePrefix("api/Advance")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class AdvancesController : ApiController
    {
        private IAdvanceService service;
        public AdvancesController(IAdvanceService _service)
        {
            service = _service;
        }

        [Route("AdvanceList")]
        public HttpResponseMessage Get()
        {
            List<AdvanceDTO> advancelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, advancelist);
        }

        [Route("AdvanceDetail")]
        public HttpResponseMessage Get(int Id)
        {
            AdvanceDTO selectedTitle = service.getAdvance(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(AdvanceDTO advanceDTO)
        {

            AdvanceDTO dto = service.newAdvance(advanceDTO);
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
        public HttpResponseMessage Put(AdvanceDTO advanceDTO)
        {
            AdvanceDTO dto = service.updateAdvance(advanceDTO);
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

            bool isDeleted = service.deleteAdvance(Id);
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
