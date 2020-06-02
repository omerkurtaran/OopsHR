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
    [RoutePrefix("api/Roles")]
    [OOPSModelValidation]
    //[Authorize]
    public class RolesController : ApiController
    {
        private IRoleService service;

        public RolesController(IRoleService _service)
        {
            service = _service;
        }

        //[Route("GetRole")]
        //public HttpResponseMessage GetCompanyBased(int companyId)
        //{
        //    List<RoleDTO> roleList = service.getAll(companyId);
        //    return Request.CreateResponse(HttpStatusCode.OK, roleList);
        //}

        [Route("GetRoleDetail")]
        public HttpResponseMessage Get(int Id)
        {
            RoleDTO selectedRole = service.getRole(Id);
            if (selectedRole == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.RolesControllerStrings.id_role);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedRole);
        }

        [Route("Add")]
        public HttpResponseMessage Post(RoleDTO roleDTO)
        {
            try
            {
                RoleDTO dto = service.newRole(roleDTO);
                if (dto != null)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.add_role);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.add_role);
            }

        }

        [Route("Update")]
        public HttpResponseMessage Put(RoleDTO roleDTO)
        {
            try
            {
                RoleDTO dto = service.updateRole(roleDTO);
                if (dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.update_role);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.update_role);
            }

        }

        [Route("Delete")]
        public HttpResponseMessage Delete(int Id)
        {
            try
            {
                bool isDeleted = service.deleteRole(Id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.RolesControllerStrings.delete_role);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.deleteError_role);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.RolesControllerStrings.deleteError_role);
            }
        }

    }
}
