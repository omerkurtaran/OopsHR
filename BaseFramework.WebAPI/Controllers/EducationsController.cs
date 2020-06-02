using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Busines.EmployeeBusinesService;
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
    [RoutePrefix("api/Educations")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class EducationsController : ApiController
    {
        private IEducationService service;
        public EducationsController(IEducationService _service)
        {
            service = _service;
        }

        [Route("EducationList")]
        public HttpResponseMessage Get()
        {
            List<EducationDTO> Educationlist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, Educationlist);
        }

        [Route("EducationDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EducationDTO selectedTitle = service.getEducation(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EducationDTO EducationDTO)
        {

            EducationDTO dto = service.newEducation(EducationDTO);
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
        public HttpResponseMessage Put(EducationDTO EducationDTO)
        {
            EducationDTO dto = service.updateEducation(EducationDTO);
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
            bool isDeleted = service.deleteEducation(Id);
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
