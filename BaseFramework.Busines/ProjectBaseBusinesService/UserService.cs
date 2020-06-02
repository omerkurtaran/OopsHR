using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.CompanyModel;
using BaseFramework.Model.ProjectBaseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Busines.ProjectBaseBusinesService
{
    public class UserService : IUserService
    {
        private readonly IUnitofWork uow;
        public UserService(IUnitofWork uow)
        {
            this.uow = uow;
        }

        public bool deleteUser(int userId)
        {
            try
            {
                var getUser = uow.GetRepository<User>().Get(z => z.Id == userId);
                uow.GetRepository<User>().Delete(getUser);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<UserDTO> getAll()
        {
            var getUserList = uow.GetRepository<User>().Get(z => z.UserCompanies).ToList();
            //return new List<UserDTO>();
            return MapperFactory.CurrentMapper.Map<List<UserDTO>>(getUserList);
        }

        public UserDTO getUser(int Id)
        {
            var getUser = uow.GetRepository<User>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public UserDTO FindwithUserName(string userName)
        {
            var getUser = uow.GetRepository<User>().Get(z => z.UserName == userName);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public UserDTO FindwithMail(string mail)
        {
            var getUser = uow.GetRepository<User>().Get(z => z.Mail == mail);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public UserDTO FindwithUsernameandMail(string mailorUserName, string password)
        {
            var getUser = uow.GetRepository<User>()
                .Get(z =>
                (z.Mail == mailorUserName || z.UserName == mailorUserName) && z.Password == password);
            return MapperFactory.CurrentMapper.Map<UserDTO>(getUser);
        }

        public UserDTO newUser(UserDTO user)
        {
            if (user.Validate())
            {
                if (!uow.GetRepository<User>().GetAll().Any(z => z.Mail == user.Mail || z.UserName == user.UserName))
                {
                    #region Step 1 User Add
                    var adedUser = MapperFactory.CurrentMapper.Map<User>(user);
                    adedUser = uow.GetRepository<User>().Add(adedUser);

                    #endregion

                    #region  Step 2 Company Add
                    var addedCompany = MapperFactory.CurrentMapper.Map<Company>(new CompanyDTO() { CompanyName = user.CompanyName });
                    addedCompany = uow.GetRepository<Company>().Add(addedCompany);
                    #endregion
                    //TODO : Role senaryosu Role Enum sonrası değişecek
                    if (user.RoleList.Count == 0)
                    {
                        user.RoleList.Add(2);
                    }
                    foreach (var roleId in user.RoleList)
                    {
                        UserCompany uc = new UserCompany();
                        uc.RoleId = roleId;
                        uc.UserId = adedUser.Id;
                        uc.CompanyId = addedCompany.Id;
                        uc = uow.GetRepository<UserCompany>().Add(uc);
                    }

                    uow.SaveChanges();
                    return MapperFactory.CurrentMapper.Map<UserDTO>(adedUser);
                }
            }
            return null;
        }

        public UserDTO updateUser(UserDTO user)
        {
            if (user.Validate())
            {
                var selectedUser = uow.GetRepository<User>().Get(z => z.Id == user.Id);
                selectedUser = MapperFactory.CurrentMapper.Map(user, selectedUser);
                uow.GetRepository<User>().Update(selectedUser);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<UserDTO>(selectedUser);

            }
            return null;
        }

        public List<UserDTO> getAllUserinRole(int RoleID)
        {
            //ICollection<User> userList = uow.GetRepository<Role>().Get(z => z.Id == RoleID).Users;
            //return MapperFactory.CurrentMapper.Map<List<UserDTO>>(userList);
            return new List<UserDTO>();
        }

        public UserDTO updateUserRole(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO updateUserCompany(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
