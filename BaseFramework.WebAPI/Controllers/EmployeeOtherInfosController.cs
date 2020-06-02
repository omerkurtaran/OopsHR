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
    [RoutePrefix("api/EmployeeOtherInfo")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class EmployeeOtherInfosController : ApiController
    {
        private IEmployeeOtherInfoService service;
        public EmployeeOtherInfosController(IEmployeeOtherInfoService _service)
        {
            service = _service;
        }

        [Route("EmployeeOtherInfoList")]
        public HttpResponseMessage Get()
        {
            List<EmployeeOtherInfoDTO> employeeOtherInfolist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, employeeOtherInfolist);
        }

        [Route("EmployeeOtherInfoDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EmployeeOtherInfoDTO selectedTitle = service.getEmployeeOtherInfo(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EmployeeOtherInfoDTO employeeOtherInfoDTO)
        {
            EmployeeOtherInfoDTO dto = service.newEmployeeOtherInfo(employeeOtherInfoDTO);
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
        public HttpResponseMessage Put(EmployeeOtherInfoDTO employeeOtherInfoDTO)
        {
            EmployeeOtherInfoDTO dto = service.updateEmployeeOtherInfo(employeeOtherInfoDTO);
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
            bool isDeleted = service.deleteEmployeeOtherInfo(Id);
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
