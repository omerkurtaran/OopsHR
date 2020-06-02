using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;


namespace BaseFramework.MapConfig.MapperProfile
{
    public class RoleProfile : ProfileBase
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
