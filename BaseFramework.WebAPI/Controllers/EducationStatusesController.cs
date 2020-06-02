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

    [RoutePrefix("api/EducationStatus")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class EducationStatusController : ApiController
    {
        private IEducationStatusService service;
        public EducationStatusController(IEducationStatusService _service)
        {
            service = _service;
        }

        [Route("EducationStatusList")]
        public HttpResponseMessage Get()
        {
            List<EducationStatusDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("EducationStatusDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EducationStatusDTO selectedTitle = service.getEducationStatus(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EducationStatusDTO accessTypeDTO)
        {

            EducationStatusDTO dto = service.newEducationStatus(accessTypeDTO);
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
        public HttpResponseMessage Put(EducationStatusDTO accessTypeDTO)
        {

            EducationStatusDTO dto = service.updateEducationStatus(accessTypeDTO);
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
            bool isDeleted = service.deleteEducationStatus(Id);
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
