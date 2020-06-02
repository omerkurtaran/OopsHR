using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Busines.ProjectBaseBusinesService;
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
    [RoutePrefix("api/Users")]
    [OOPSModelValidation]
    //[Authorize]
    public class UsersController : ApiController
    {

        private IUserService service;

        public UsersController(IUserService _service)
        {
            service = _service;
        }
        [Route("GetUser")]
        public HttpResponseMessage Get()
        {
            List<UserDTO> userlist = service.getAll();
            return Request.CreateResponse(HttpStatusCode.OK, userlist);
        }

        [Route("GetUserDetail")]
        public HttpResponseMessage Get(int Id)
        {
            UserDTO selectedUser = service.getUser(Id);
            if (selectedUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Id + sysLanguage.UsersControllerStrnigs.notFound_user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, selectedUser);
        }

        [Route("FindUserwithName")]
        public HttpResponseMessage FindUserwithUserName(string userName)
        {
            UserDTO selectedUser = service.FindwithUserName(userName);
            if (selectedUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, userName + sysLanguage.UsersControllerStrnigs.notFound_user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        [Route("FindUserwithMail")]
        public HttpResponseMessage FindUserwithMaile(string mail)
        {
            UserDTO selectedUser = service.FindwithMail(mail);
            if (selectedUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, mail + sysLanguage.UsersControllerStrnigs.notFound_user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }

        [Route("FindUserwithMailorNamePassword")]
        public HttpResponseMessage FindwithUsernameandMail(string mailorUserName, string password)
        {
            UserDTO selectedUser = service.FindwithUsernameandMail(mailorUserName, password);
            if (selectedUser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, sysLanguage.UsersControllerStrnigs.notFound_user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "");
        }
        [Route("Add")]
        [HttpPost]
        public HttpResponseMessage AddUser(UserDTO userDTO)
        {
            try
            {
                UserDTO dto = service.newUser(userDTO);
                if (dto != null)
                {
                    HttpResponseMessage message = Request.CreateResponse(HttpStatusCode.Created, dto);
                    message.Headers.Location = new Uri(Request.RequestUri + "/" + dto.Id);
                    return message;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.add_user);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.add_user);
            }

        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage UpdateUser(UserDTO userDTO)
        {
            try
            {
                UserDTO dto = service.updateUser(userDTO);
                if (dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.update_user);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.update_user);
            }

        }

        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int Id)
        {
            try
            {
                bool isDeleted = service.deleteUser(Id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, sysLanguage.UsersControllerStrnigs.delete_user);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.deleteError_user);
                }
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.SeeOther, sysLanguage.UsersControllerStrnigs.deleteError_user);
            }
        }


    }
}
