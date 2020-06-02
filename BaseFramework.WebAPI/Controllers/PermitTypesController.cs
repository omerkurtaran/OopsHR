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
    [RoutePrefix("api/PermitType")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class PermitTypesController : ApiController
    {
        private IPermitTypeService service;
        public PermitTypesController(IPermitTypeService _service)
        {
            service = _service;
        }

        [Route("PermitTypeList")]
        public HttpResponseMessage Get()
        {
            List<PermitTypeDTO> permitTypelist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, permitTypelist);
        }

        [Route("PermitTypeDetail")]
        public HttpResponseMessage Get(int Id)
        {
            PermitTypeDTO selectedTitle = service.getPermitType(Id);
            if (selectedTitle == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CompanyTitlesControllerStrings.id_title);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedTitle);
        }

        [Route("Add")]
        public HttpResponseMessage Post(PermitTypeDTO permitTypeDTO)
        {
            PermitTypeDTO dto = service.newPermitType(permitTypeDTO);
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
        public HttpResponseMessage Put(PermitTypeDTO permitTypeDTO)
        {
            PermitTypeDTO dto = service.updatePermitType(permitTypeDTO);
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
            bool isDeleted = service.deletePermitType(Id);
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