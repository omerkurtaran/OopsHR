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
    [RoutePrefix("api/Cities")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CitiesController : ApiController
    {
        private ICityService service;

        public CitiesController(ICityService _service)
        {
            service = _service;
        }

        [Route("CityList")]
        public HttpResponseMessage Get()
        {
            List<CityDTO> cityList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, cityList);
        }

        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            CityDTO city = service.getCity(Id);
            if (city == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CitiesControllerStrings.Id_CityMessage) ;
            }
            return Request.CreateResponse(HttpStatusCode.OK, city);
        }

        [Route("FindByName")]
        public HttpResponseMessage FindByName(string name)
        {
            List<CityDTO> cityList = service.getCityName(name);
            return Request.CreateResponse(HttpStatusCode.OK, cityList);
        }

        [Route("FindByCode")]
        public HttpResponseMessage FindByCode(string code)
        {
            CityDTO city = service.getCityCode(code);
            return Request.CreateResponse(HttpStatusCode.OK, city);
        }

        [Route("FindByCountryinCity")]
        public HttpResponseMessage FindByCountryinCity(int Id)
        {
            List<CityDTO> countryincityList = service.getCountryinCity(Id);
            return Request.CreateResponse(HttpStatusCode.OK, countryincityList);
        }
    }
}
