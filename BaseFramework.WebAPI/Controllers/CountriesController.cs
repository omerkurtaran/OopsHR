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
    [RoutePrefix("api/Countries")]
    [OOPSModelValidation]
    [Authorize]
    [OOPSErrorFilter]
    public class CountriesController : ApiController
    {
        private ICountryService service;

        public CountriesController(ICountryService _service)
        {
            service = _service;
        }

        [Route("CountryList")]
        public HttpResponseMessage Get()
        {
            List<CountryDTO> countryList = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, countryList);
        }

        [Route("SelectById")]
        public HttpResponseMessage Get(int Id)
        {
            CountryDTO country = service.getCountry(Id);
            if (country == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.CountriesControllerStrings.id_Country);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        [Route("FindByName")]
        public HttpResponseMessage FindByName(string name)
        {
            List<CountryDTO> countryList = service.getCountryName(name);
            return Request.CreateResponse(HttpStatusCode.OK, countryList);
        }

        [Route("FindByCode")]
        public HttpResponseMessage FindByCode(string code)
        {
            CountryDTO country= service.getCountryCode(code);
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        [Route("FindByLngCode")]
        public HttpResponseMessage FindByLngCode(string code)
        {
            CountryDTO country = service.getCountryLangCode(code);
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

    }
}
