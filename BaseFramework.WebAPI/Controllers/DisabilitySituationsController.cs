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

    [RoutePrefix("api/DisabilitySituation")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class DisabilitySituationController : ApiController
    {
        private IDisabilitySituationService service;
        public DisabilitySituationController(IDisabilitySituationService _service)
        {
            service = _service;
        }

        [Route("DisabilitySituationList")]
        public HttpResponseMessage Get()
        {
            List<DisabilitySituationDTO> accessTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, accessTypelist);
        }

        [Route("DisabilitySituationDetail")]
        public HttpResponseMessage Get(int Id)
        {
            DisabilitySituationDTO selectedTitle = service.getDisabilitySituation(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(DisabilitySituationDTO accessTypeDTO)
        {
        
                DisabilitySituationDTO dto = service.newDisabilitySituation(accessTypeDTO);
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
        public HttpResponseMessage Put(DisabilitySituationDTO accessTypeDTO)
        {
          
                DisabilitySituationDTO dto = service.updateDisabilitySituation(accessTypeDTO);
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
          
                bool isDeleted = service.deleteDisabilitySituation(Id);
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
