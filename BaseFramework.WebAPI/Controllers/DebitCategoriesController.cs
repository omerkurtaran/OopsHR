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
    [RoutePrefix("api/DebitCategories")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class DebitCategoriesController : ApiController
    {
        private IDebitCategoryService service;
        public DebitCategoriesController(IDebitCategoryService _service)
        {
            service = _service;
        }

        [Route("DebitCategoryList")]
        public HttpResponseMessage Get()
        {
            List<DebitCategoryDTO> DebitCategorylist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, DebitCategorylist);
        }

        [Route("DebitCategoryDetail")]
        public HttpResponseMessage Get(int Id)
        {
            DebitCategoryDTO selectedTitle = service.getDebitCategory(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(DebitCategoryDTO DebitCategoryDTO)
        {

            DebitCategoryDTO dto = service.newDebitCategory(DebitCategoryDTO);
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
        public HttpResponseMessage Put(DebitCategoryDTO DebitCategoryDTO)
        {
            DebitCategoryDTO dto = service.updateDebitCategory(DebitCategoryDTO);
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
            bool isDeleted = service.deleteDebitCategory(Id);
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
