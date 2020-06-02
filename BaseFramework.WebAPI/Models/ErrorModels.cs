using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseFramework.WebAPI.Models
{
    public class ErrorModels
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ErrorMessage { get; set; }
    }
}