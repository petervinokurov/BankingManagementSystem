using AutoMapper;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
namespace BankingManagementSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<User, BmsUserProjection>();
            CreateMap<RoleClaim, RoleClaimDto>().ReverseMap();
            CreateMap<Role, BmsRoleProjection>();
            CreateMap<RoleDto, Role>()
                .ForMember(d => d.RoleClaims, opt => opt.MapFrom(f => f.RoleClaims))
                .ForMember(d => d.RoleClaims, opt => opt.Condition(f => f.RoleClaims != default))
                .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                .ForMember(d => d.Name, opt => opt.Condition(f => f.Name != default));
        }
    }
}
