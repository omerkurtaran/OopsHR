using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Model.ProjectBaseDTO;
using BaseFramework.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/Districts")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class DistrictsController : ApiController
    {
        private IDistrictService service;

        public DistrictsController(IDistrictService _service)
        {
            service = _service;
        }


        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            DistrictDTO district = service.getDistrict(Id);
            if (district == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.DistrictsControllerStrings.id_District);
            }
            return Request.CreateResponse(HttpStatusCode.OK, district);
        }

        [Route("FindByName")]
        public HttpResponseMessage FindByName(string name)
        {
            List<DistrictDTO> districtList = service.getDistrictName(name);
            return Request.CreateResponse(HttpStatusCode.OK, districtList);
        }

        [Route("FindByCode")]
        public HttpResponseMessage FindByCode(string code)
        {
            DistrictDTO district = service.getDistrictCode(code);
            return Request.CreateResponse(HttpStatusCode.OK, district);
        }

        [Route("FindByCityinDistrict")]
        public HttpResponseMessage FindByCityinDistrict(int Id)
        {
            List<DistrictDTO> cityindistrictList = service.getCityinDistrict(Id);
            return Request.CreateResponse(HttpStatusCode.OK, cityindistrictList);
        }
    }
}
