using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Model.Login;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BaseFramework.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IUserService service;
        public LoginController(IUserService _service)
        {
            service = _service;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDTO logonUser)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(UserDTO dto)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}