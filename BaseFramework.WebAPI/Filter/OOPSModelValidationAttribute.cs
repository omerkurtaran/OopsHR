using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BaseFramework.WebAPI.Filter
{
    public class OOPSModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var errorList = actionContext.ModelState.Values.SelectMany(v => v.Errors);
                List<string> strList = new List<string>();
                foreach (var error in errorList)
                {
                    strList.Add(error.ErrorMessage);
                }
                //var errorMessage = string.Join("</br>", errorList);

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, JsonConvert.SerializeObject(strList));
            }

        }
    }
}