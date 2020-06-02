using BaseFramework.WebAPI.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;

namespace BaseFramework.WebAPI.Tools
{
    public static class OOPSResult
    {
        public static HttpResponseMessage OKResult(object data)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
        public static HttpResponseMessage OKResult(object data, Uri uri, HttpStatusCode code)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            response.StatusCode = code;
            if (uri != null)
            {
                response.Headers.Location = uri;
            }
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}