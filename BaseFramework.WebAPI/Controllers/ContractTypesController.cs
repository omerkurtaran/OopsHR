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

    [RoutePrefix("api/ContractType")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class ContractTypeController : ApiController
    {
        private IContractTypeService service;
        public ContractTypeController(IContractTypeService _service)
        {
            service = _service;
        }

        [Route("ContractTypeList")]
        public HttpResponseMessage Get()
        {
            List<ContractTypeDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("ContractTypeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            ContractTypeDTO selectedTitle = service.getContractType(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(ContractTypeDTO contractTypeDTO)
        {

            ContractTypeDTO dto = service.newContractType(contractTypeDTO);
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
        public HttpResponseMessage Put(ContractTypeDTO contractTypeDTO)
        {

            ContractTypeDTO dto = service.updateContractType(contractTypeDTO);
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
            bool isDeleted = service.deleteContractType(Id);
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
