using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Model.EmployeeModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    public class DebitsController : ApiController
    {
        private IDebitService service;
        public DebitsController(IDebitService _service)
        {
            service = _service;
        }
        [Route("DebitList")]
        public HttpResponseMessage Get()
        {
            List<DebitDTO> debitList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, debitList);
        }
        [Route("DebitDetail")]
        public HttpResponseMessage Get(int Id)
        {
            DebitDTO selectedDebit = service.getDebit(Id);
            if (selectedDebit == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedDebit);
        }
        [Route("Add")]
        public HttpResponseMessage Post(DebitDTO debitDTO)
        {
            DebitDTO dto = service.newDebit(debitDTO);
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
        public HttpResponseMessage Put(DebitDTO debitDTO)
        {
            DebitDTO dto = service.updateDebit(debitDTO);
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
            bool isDeleted = service.deleteDebit(Id);
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
