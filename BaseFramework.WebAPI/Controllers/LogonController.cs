using BaseFramework.Model.Login;
using BaseFramework.WebAPI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseFramework.WebAPI.Controllers
{

    [RoutePrefix("api/Logon")]
    [OOPSModelValidation]
    public class LogonController : ApiController
    {
        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginDTO login)
        {
            if (login.UserName == "Ahmet" && login.Password == "123")
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, sysLanguage.LogonControllerStrings.login_user);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, sysLanguage.LogonControllerStrings.loginFailed_user);
            }
        }
    }
}
