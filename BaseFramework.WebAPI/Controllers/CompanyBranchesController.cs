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
    [RoutePrefix("api/CompanyBranches")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CompanyBranchesController : ApiController
    {
        private ICompanyBranchService service;

        public CompanyBranchesController(ICompanyBranchService _service)
        {
            service = _service;
        }

        [Route("CompanyBranchList")]
        public HttpResponseMessage Get()
        {
            List<CompanyBranchDTO> CompanyBranchList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, CompanyBranchList);
        }

        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            CompanyBranchDTO selectedCompanyBranch = service.getCompanyBranch(Id);
            if (selectedCompanyBranch == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyBranchesControllerStrings.id_branch);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedCompanyBranch);
        }

        [Route("SelectByCompany")]
        public HttpResponseMessage GetwithCompanyId(int companyId)
        {
            List<CompanyBranchDTO> selectedCompanyBranchList = service.getSelectByCompanyId(companyId);
            return Request.CreateResponse(HttpStatusCode.OK, selectedCompanyBranchList);
        }

        [Route("Add")]
        public HttpResponseMessage Post(CompanyBranchDTO CompanyBranchDTO)
        {
            CompanyBranchDTO dto = service.newCompanyBranch(CompanyBranchDTO);
            if (dto != null)
            {
                HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyBranchesControllerStrings.add_branch);
            }
        }

        [Route("Update")]
        public HttpResponseMessage Put(CompanyBranchDTO CompanyBranchDTO)
        {

            CompanyBranchDTO dto = service.updateCompanyBranch(CompanyBranchDTO);
            if (dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyBranchesControllerStrings.update_branch);
            }


        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            bool isDeleted = service.deleteCompanyBranch(Id);
            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.CompanyBranchesControllerStrings.delete_branch);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.CompanyBranchesControllerStrings.delete_branchError);
            }

        }
    }
}
