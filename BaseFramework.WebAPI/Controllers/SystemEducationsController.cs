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
    [RoutePrefix("api/SystemEducation")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class SystemEducationController : ApiController
    {
        private ISystemEducationService service;
        public SystemEducationController(ISystemEducationService _service)
        {
            service = _service;
        }

        [Route("SystemEducationList")]
        public HttpResponseMessage Get()
        {
            List<SystemEducationDTO> SystemEducationlist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, SystemEducationlist);
        }

        [Route("SystemEducationDetail")]
        public HttpResponseMessage Get(int Id)
        {
            SystemEducationDTO selectedTitle = service.getSystemEducation(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(SystemEducationDTO SystemEducationDTO)
        {

            SystemEducationDTO dto = service.newSystemEducation(SystemEducationDTO);
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
        public HttpResponseMessage Put(SystemEducationDTO SystemEducationDTO)
        {
            SystemEducationDTO dto = service.updateSystemEducation(SystemEducationDTO);
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
            bool isDeleted = service.deleteSystemEducation(Id);
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
