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
    [RoutePrefix("api/Overtime")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class OvertimesController : ApiController
    {
        private IOvertimeService service;
        public OvertimesController(IOvertimeService _service)
        {
            service = _service;
        }

        [Route("OvertimeList")]
        public HttpResponseMessage Get()
        {
            List<OvertimeDTO> Overtimelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, Overtimelist);
        }

        [Route("OvertimeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            OvertimeDTO selectedTitle = service.getOvertime(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(OvertimeDTO OvertimeDTO)
        {

            OvertimeDTO dto = service.newOvertime(OvertimeDTO);
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
        public HttpResponseMessage Put(OvertimeDTO OvertimeDTO)
        {
            OvertimeDTO dto = service.updateOvertime(OvertimeDTO);
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
            bool isDeleted = service.deleteOvertime(Id);
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
