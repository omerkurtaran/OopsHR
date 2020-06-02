using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BaseFramework.WebAPI.Models
{
    internal class UserInfo
    {
        internal static UserDTO CurrentUser()
        {
            var claim = ClaimsPrincipal.Current.Identities.First().Claims;
            return new UserDTO()
            {
                UserName = claim.First(z => z.Type == "UserName").Value,

            };
        }
    }
}