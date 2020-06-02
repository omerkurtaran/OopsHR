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
    [RoutePrefix("api/BankInformation")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class BankInformationsController : ApiController
    {
        private IBankInformationService service;
        public BankInformationsController(IBankInformationService _service)
        {
            service = _service;
        }

        [Route("BankInformationList")]
        public HttpResponseMessage Get()
        {
            List<BankInformationDTO> bankInformationlist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, bankInformationlist);
        }

        [Route("BankInformationDetail")]
        public HttpResponseMessage Get(int Id)
        {
            BankInformationDTO selectedTitle = service.getBankInformation(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(BankInformationDTO bankInformationDTO)
        {
            BankInformationDTO dto = service.newBankInformation(bankInformationDTO);
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
        public HttpResponseMessage Put(BankInformationDTO bankInformationDTO)
        {
            BankInformationDTO dto = service.updateBankInformation(bankInformationDTO);
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
            bool isDeleted = service.deleteBankInformation(Id);
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
