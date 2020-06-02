using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Model.CompanyModel;
using BaseFramework.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/CompanyDepartments")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CompanyDepartmentsController : ApiController
    {
        private ICompanyDeparmantService service;
        public CompanyDepartmentsController(ICompanyDeparmantService _service)
        {
            service = _service;
        }

        [Route("DepartmentList")]
        public HttpResponseMessage Get()
        {
            List<CompanyDepartmentDTO> DepartmentList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, DepartmentList);
        }

        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            CompanyDepartmentDTO selectedDepertmant = service.getDepartmant(Id);
            if (selectedDepertmant == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyDepartmentsControllerStrings.id_department);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedDepertmant);
        }

        [Route("Add")]
        public HttpResponseMessage Post(CompanyDepartmentDTO deparmentDTO)
        {

            CompanyDepartmentDTO dto = service.newDepartmant(deparmentDTO);
            if (dto != null)
            {
                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyDepartmentsControllerStrings.add_department);
            }


        }

        [Route("Update")]
        public HttpResponseMessage Put(CompanyDepartmentDTO deparmentDTO)
        {

            CompanyDepartmentDTO dto = service.updateDepartmant(deparmentDTO);
            if (dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyDepartmentsControllerStrings.update_department);
            }


        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {

            bool isDeleted = service.deleteDepartmant(Id);
            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.CompanyDepartmentsControllerStrings.delete_department);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyDepartmentsControllerStrings.delete_departmentError);
            }

        }


    }
}
