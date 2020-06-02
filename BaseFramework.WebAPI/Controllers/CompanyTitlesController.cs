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
    [RoutePrefix("api/Title")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CompanyTitleController : ApiController
    {
        private ICompanyTitleService service;

        public CompanyTitleController(ICompanyTitleService _service)
        {
            service = _service;
        }
        [Route("GetTitle")]
        public HttpResponseMessage Get()
        {
            List<CompanyTitleDTO> titlelist = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, titlelist);
        }

        [Route("GetTitleDetail")]
        public HttpResponseMessage Get(int Id)
        {
            CompanyTitleDTO selectedTitle = service.getTitle(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("FindwithTitle")]
        public HttpResponseMessage FindwithTitle(string Name)
        {
            CompanyTitleDTO selectedTitle = service.FindwithTitle(Name);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Name + sysLanguage.CompanyTitlesControllerStrings.name_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        [Route("SelectByCompany")]
        public HttpResponseMessage GetwithCompanyId(int companyId)
        {
            List<CompanyTitleDTO> selectedCompanyTitleList = service.getSelectByCompanyId(companyId);
            if (selectedCompanyTitleList == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, companyId + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedCompanyTitleList);
        }

        [Route("Add")]
        public HttpResponseMessage Post(CompanyTitleDTO titleDTO)
        {

            CompanyTitleDTO dto = service.newTitle(titleDTO);
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
        public HttpResponseMessage Put(CompanyTitleDTO titleDTO)
        {

            CompanyTitleDTO dto = service.updateTitle(titleDTO);
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

            bool isDeleted = service.deleteTitle(Id);
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
