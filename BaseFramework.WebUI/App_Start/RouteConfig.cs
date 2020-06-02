using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaseFramework.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "EmpDetail",
              url: "EmployeeDetail/{id}",
              defaults: new { controller = "Employees", action = "Detail", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "UserRegister",
               url: "register",
               defaults: new { controller = "Login", action = "UserRegister", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "LoginPage",
               url: "login",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
