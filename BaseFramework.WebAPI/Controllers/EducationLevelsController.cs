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

    [RoutePrefix("api/EducationLevel")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class EducationLevelController : ApiController
    {
        private IEducationLevelService service;
        public EducationLevelController(IEducationLevelService _service)
        {
            service = _service;
        }

        [Route("EducationLevelList")]
        public HttpResponseMessage Get()
        {
            List<EducationLevelDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("EducationLevelDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EducationLevelDTO selectedTitle = service.getEducationLevel(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EducationLevelDTO accessTypeDTO)
        {
            EducationLevelDTO dto = service.newEducationLevel(accessTypeDTO);
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
        public HttpResponseMessage Put(EducationLevelDTO accessTypeDTO)
        {

            EducationLevelDTO dto = service.updateEducationLevel(accessTypeDTO);
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
            bool isDeleted = service.deleteEducationLevel(Id);
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
