using AutoMapper.EquivalencyExpression;
using BaseFramework.Core.Mapper;
using BaseFramework.Entity.ProjectBaseEntity;
using BaseFramework.Model.ProjectBaseDTO;

namespace BaseFramework.MapConfig.MapperProfile
{
    public class UserProfile : ProfileBase
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap()
                .ForMember(dest => dest.UserCompanies, src => src.Ignore());
        }
    }
}
