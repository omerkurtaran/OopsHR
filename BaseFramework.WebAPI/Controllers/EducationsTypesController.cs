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
    [RoutePrefix("api/EducationsTypes")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class EducationsTypesController : ApiController
    {
        private IEducationsTypeService service;
        public EducationsTypesController(IEducationsTypeService _service)
        {
            service = _service;
        }

        [Route("EducationsTypeList")]
        public HttpResponseMessage Get()
        {
            List<EducationsTypeDTO> EducationsTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, EducationsTypelist);
        }

        [Route("EducationsTypeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EducationsTypeDTO selectedTitle = service.getEducationsType(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EducationsTypeDTO EducationsTypeDTO)
        {

            EducationsTypeDTO dto = service.newEducationsType(EducationsTypeDTO);
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
        public HttpResponseMessage Put(EducationsTypeDTO EducationsTypeDTO)
        {
            EducationsTypeDTO dto = service.updateEducationsType(EducationsTypeDTO);
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
            bool isDeleted = service.deleteEducationsType(Id);
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
