using BaseFramework.Model.Login;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseFramework.WebUI.Models.LoginModel
{
    public class LoginViewModel
    {
        public LoginDTO LoginDTO { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}