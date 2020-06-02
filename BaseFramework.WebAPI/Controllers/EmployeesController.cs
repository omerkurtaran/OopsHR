using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Model.EmployeeModelDTO;
using BaseFramework.WebAPI.Filter;
using BaseFramework.WebAPI.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/Employee")]
    [OOPSModelValidation]
    //[Authorize]
    public class EmployeeController : ApiController
    {
        private IEmployeeService service;
        public EmployeeController(IEmployeeService _service)
        {
            service = _service;
        }

        [Route("EmployeeList")]
        [HttpGet]
        public HttpResponseMessage GetCompany()
        {
            int companyId = 1;
            List<EmployeeDTO> employeelist = service.getCompanyEmployees(companyId);
            return OOPSResult.OKResult(employeelist);
        }

        [Route("EmployeeDetail")]
        public HttpResponseMessage Get()
        {
            int companyId = 1;
            int emplooyeeId = 3;
            EmployeeDTO selectedEmployee = service.getEmployee(emplooyeeId);
            if (selectedEmployee == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, emplooyeeId + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return OOPSResult.OKResult(selectedEmployee);
        }

        [Route("Add")]
        public HttpResponseMessage Post(EmployeeDTO employeeDTO)
        {
            try
            {
                EmployeeDTO dto = service.newEmployee(employeeDTO);
                if (dto != null)
                {
                    return OOPSResult.OKResult(dto, new Uri(Request.RequestUri + "/" + dto.Id), HttpStatusCode.Created);
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
        public HttpResponseMessage Put(EmployeeDTO employeeDTO)
        {
            try
            {
                EmployeeDTO dto = service.updateEmployee(employeeDTO);
                if (dto != null)
                {
                    return OOPSResult.OKResult(dto, null, HttpStatusCode.OK);
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
                bool isDeleted = service.deleteEmployee(Id);
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
