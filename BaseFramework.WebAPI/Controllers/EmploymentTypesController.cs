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

    [RoutePrefix("api/EmploymentType")]
    [OOPSModelValidation]
    [Authorize]

    public class EmploymentTypeController : ApiController
    {
        private IEmploymentTypeService service;
        public EmploymentTypeController(IEmploymentTypeService _service)
        {
            service = _service;
        }

        [Route("EmploymentTypeList")]
        public HttpResponseMessage Get()
        {
            List<EmploymentTypeDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("EmploymentTypeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EmploymentTypeDTO selectedTitle = service.getEmploymentType(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EmploymentTypeDTO accessTypeDTO)
        {
            try
            {
                EmploymentTypeDTO dto = service.newEmploymentType(accessTypeDTO);
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
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.add_title);
            }

        }

        [Route("Update")]
        public HttpResponseMessage Put(EmploymentTypeDTO accessTypeDTO)
        {
            try
            {
                EmploymentTypeDTO dto = service.updateEmploymentType(accessTypeDTO);
                if (dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.update_title);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.update_title);
            }

        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                bool isDeleted = service.deleteEmploymentType(Id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.CompanyTitlesControllerStrings.delete_title);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.delete_titleError);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyTitlesControllerStrings.delete_titleError);
            }
        }
    }
}
