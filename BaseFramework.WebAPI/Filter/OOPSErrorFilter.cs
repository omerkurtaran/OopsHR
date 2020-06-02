using BaseFramework.WebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BaseFramework.WebAPI.Filter
{
    public class OOPSErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            ErrorModels models = new ErrorModels()
            {
                ActionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                ControllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                ErrorMessage = actionExecutedContext.Exception.InnerException.InnerException.Message

            };
            var errroObject = JsonConvert.SerializeObject(models);
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, errroObject);
            //Log
        }
    }
}