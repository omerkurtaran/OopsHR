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
    [RoutePrefix("api/Demands")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class DemandsController : ApiController
    {
        private IDemandService service;
        public DemandsController(IDemandService _service)
        {
            service = _service;
        }

        [Route("DemandList")]
        public HttpResponseMessage Get()
        {
            List<DemandDTO> Demandlist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, Demandlist);
        }

        [Route("DemandDetail")]
        public HttpResponseMessage Get(int Id)
        {
            DemandDTO selectedTitle = service.getDemand(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(DemandDTO DemandDTO)
        {

            DemandDTO dto = service.newDemand(DemandDTO);
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
        public HttpResponseMessage Put(DemandDTO DemandDTO)
        {
            DemandDTO dto = service.updateDemand(DemandDTO);
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
            bool isDeleted = service.deleteDemand(Id);
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
