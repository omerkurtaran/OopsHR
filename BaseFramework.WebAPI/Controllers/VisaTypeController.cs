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
    [RoutePrefix("api/VisaType")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class VisaTypeController : ApiController
    {
        private IVisaTypeService service;
        public VisaTypeController(IVisaTypeService _service)
        {
            service = _service;
        }

        [Route("VisaTypeList")]
        public HttpResponseMessage Get()
        {
            List<VisaTypeDTO> VisaTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, VisaTypelist);
        }

        [Route("VisaTypeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            VisaTypeDTO selectedTitle = service.getVisaType(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(VisaTypeDTO VisaTypeDTO)
        {

            VisaTypeDTO dto = service.newVisaType(VisaTypeDTO);
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
        public HttpResponseMessage Put(VisaTypeDTO VisaTypeDTO)
        {
            VisaTypeDTO dto = service.updateVisaType(VisaTypeDTO);
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

            bool isDeleted = service.deleteVisaType(Id);
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
