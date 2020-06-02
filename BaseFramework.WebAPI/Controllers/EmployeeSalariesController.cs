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

    [RoutePrefix("api/EmployeeSalary")]
    [OOPSModelValidation]
    [Authorize]
    public class EmployeeSalaryController : ApiController
    {
        private IEmployeeSalaryService service;
        public EmployeeSalaryController(IEmployeeSalaryService _service)
        {
            service = _service;
        }

        [Route("EmployeeSalaryList")]
        public HttpResponseMessage Get()
        {
            List<EmployeeSalaryDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("EmployeeSalaryDetail")]
        public HttpResponseMessage Get(int Id)
        {
            EmployeeSalaryDTO selectedTitle = service.getEmployeeSalary(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EmployeeSalaryDTO accessTypeDTO)
        {
            try
            {
                EmployeeSalaryDTO dto = service.newEmployeeSalary(accessTypeDTO);
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
        public HttpResponseMessage Put(EmployeeSalaryDTO accessTypeDTO)
        {
            try
            {
                EmployeeSalaryDTO dto = service.updateEmployeeSalary(accessTypeDTO);
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
                bool isDeleted = service.deleteEmployeeSalary(Id);
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
