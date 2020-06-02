using BaseFramework.Busines.EmployeeBusinesInterface;
using BaseFramework.Model.EmployeeModelDTO;
using BaseFramework.WebAPI.Filter;
using BaseFramework.WebAPI.Models;
using BaseFramework.WebAPI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{
    [RoutePrefix("api/StaticTypes")]
    [OOPSModelValidation]
    //[Authorize]
    public class StaticTypesController : ApiController
    {
        private readonly IBloodGroupService bloodgroupService;
        private readonly IAccessTypeService accessTypeService;
        public StaticTypesController(
            IBloodGroupService _bloodgroupService,
            IAccessTypeService _accessTypeService)
        {
            bloodgroupService = _bloodgroupService;
            accessTypeService = _accessTypeService;
        }

        [Route("StaticTypeList")]
        public HttpResponseMessage Get()
        {
            List<BloodGroupDTO> bloodGroupList = bloodgroupService.getAll();
            List<AccessTypeDTO> accessTypeList = accessTypeService.getAll();
            StaticTypesViewModel viewModel = new StaticTypesViewModel()
            {
                bloodGroupList = bloodGroupList,
                accessTypeList = accessTypeList
            };

            return OOPSResult.OKResult(viewModel);

        }

    }
}
