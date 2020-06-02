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
    [RoutePrefix("api/Companies")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CompaniesController : ApiController
    {
        private ICompanyService service;

        public CompaniesController(ICompanyService _service)
        {
            service = _service;
        }

        [Route("CompanyList")]
        public HttpResponseMessage Get()
        {
            List<CompanyDTO> CompanyList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, CompanyList);
        }

        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            CompanyDTO selectedCompany = service.getCompany(Id);
            if (selectedCompany == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompaniesControllerStrings.id_company);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedCompany);
        }

        [Route("Add")]
        public HttpResponseMessage Post(CompanyDTO CompanyDTO)
        {

            CompanyDTO dto = service.newCompany(CompanyDTO);
            if (dto != null)
            {
                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompaniesControllerStrings.add_company);
            }


        }

        [Route("Update")]
        public HttpResponseMessage Put(CompanyDTO CompanyDTO)
        {

            CompanyDTO dto = service.updateCompany(CompanyDTO);
            if (dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompaniesControllerStrings.update_company);
            }

        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {

            bool isDeleted = service.deleteCompany(Id);
            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.CompaniesControllerStrings.delete_company);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompaniesControllerStrings.deleteError_company);
            }
        }
    }

}
