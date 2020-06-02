using BaseFramework.Busines.ProjectBaseBusinesInterface;
using BaseFramework.Core.Data.UnitOfWork;
using BaseFramework.Core.Mapper;
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
    public class RoleService : IRoleService
    {
        private readonly IUnitofWork uow;
        public RoleService(IUnitofWork uow)
        {
            this.uow = uow;
        }
        public bool deleteRole(int roleId)
        {
            try
            {
                var getRole = uow.GetRepository<Role>().Get(z => z.Id == roleId);
                uow.GetRepository<Role>().Delete(getRole);
                uow.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<RoleDTO> getAll()
        {
            var getRoleList = uow.GetRepository<CompanyDTO>().Get(null, null, null).ToList();

            return MapperFactory.CurrentMapper.Map<List<RoleDTO>>(getRoleList);
        }

        public RoleDTO getRole(int Id)
        {
            var getRole = uow.GetRepository<Role>().Get(z => z.Id == Id);
            return MapperFactory.CurrentMapper.Map<RoleDTO>(getRole);
        }

        public RoleDTO newRole(RoleDTO role)
        {
            if (!uow.GetRepository<Role>().GetAll().Any(z => z.Name == role.Name))
            {
                var adedRole = MapperFactory.CurrentMapper.Map<Role>(role);
                adedRole = uow.GetRepository<Role>().Add(adedRole);
                uow.SaveChanges();
                return MapperFactory.CurrentMapper.Map<RoleDTO>(adedRole);
            }
            else
            {
                return null;
            }
        }

        public RoleDTO updateRole(RoleDTO role)
        {
            var selectedRole = uow.GetRepository<Role>().Get(z => z.Id == role.Id);
            selectedRole = MapperFactory.CurrentMapper.Map(role, selectedRole);
            uow.GetRepository<Role>().Update(selectedRole);
            uow.SaveChanges();
            return MapperFactory.CurrentMapper.Map<RoleDTO>(selectedRole);
        }
    }
}
