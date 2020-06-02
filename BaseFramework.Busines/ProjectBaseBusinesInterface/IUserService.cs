using BaseFramework.Core.Business;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesInterface
{
    public interface IUserService : IServiceBase
    {
        List<UserDTO> getAll();
        List<UserDTO> getAllUserinRole(int RoleID);
        UserDTO newUser(UserDTO user);
        UserDTO updateUser(UserDTO user);
        UserDTO updateUserRole(UserDTO user);
        UserDTO updateUserCompany(UserDTO user);
        bool deleteUser(int userId);
        UserDTO getUser(int Id);
        UserDTO FindwithUserName(string userName);
        UserDTO FindwithMail(string mail);
        UserDTO FindwithUsernameandMail(string mailorUserName, string password);
    }
}
