using System;
using AutoMapper;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Services;

namespace BankingManagementSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile(ICryptographyService cryptographyService)
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<User, UserDto>();
            CreateMap<RoleClaim, ClaimDto>().ReverseMap();
            CreateMap<UserClaim, ClaimDto>().ReverseMap();
            CreateMap<Role, BmsRoleProjection>();

            CreateMap<NewUserDto, User>()
                .ForMember(d => d.UserName, 
                    opt => opt.MapFrom(f => f.Username))
                .ForMember(d => d.NormalizedUserName, 
                    opt => opt.MapFrom(f => f.Username.ToUpperInvariant()))
                .ForMember(d => d.Email, 
                    opt => opt.MapFrom(f => f.Email))
                .ForMember(d => d.NormalizedEmail, 
                    opt => opt.MapFrom(f => f.Email.ToUpperInvariant()))
                .ForMember(d => d.PasswordHash,
                    opt => opt.MapFrom(f => cryptographyService.GetPasswordHash(f.Password)))
                .ForMember(d => d.TwoFactorEnabled, 
                    opt => opt.MapFrom(f => false))
                .ForMember(d => d.SecurityStamp,
                    opt => opt.MapFrom(f => Guid.NewGuid().ToString()))
                .ForMember(d => d.ConcurrencyStamp,
                    opt => opt.MapFrom(f => Guid.NewGuid().ToString()))
                .ForMember(d => d.Roles, 
                    opt => opt.MapFrom(f => f.Roles))
                .ForMember(d => d.Roles, 
                    opt => opt.Condition(f => f.Roles != default))
                .ForMember(d => d.Claims, 
                    opt => opt.MapFrom(f => f.Claims))
                .ForMember(d => d.Claims, 
                    opt => opt.Condition(f => f.Claims != default));
            CreateMap<UserDto, User>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(f => f.Roles))
                .ForMember(d => d.Roles, opt => opt.Condition(f => f.Roles != default))
                .ForMember(d => d.Claims, opt => opt.MapFrom(f => f.Claims))
                .ForMember(d => d.Claims, opt => opt.Condition(f => f.Claims != default))
                .ForMember(d => d.Email, opt => opt.MapFrom(f => f.Email))
                .ForMember(d => d.Email, opt => opt.Condition(f => f.Email != default))
                .ForMember(d => d.NormalizedEmail, opt => opt.MapFrom(f => f.Email.ToUpperInvariant()))
                .ForMember(d => d.NormalizedEmail, opt => opt.Condition(f => f.Email != default))
                .ForMember(d => d.UserName, opt => opt.MapFrom(f => f.UserName))
                .ForMember(d => d.UserName, opt => opt.Condition(f => f.UserName != default))
                .ForMember(d => d.NormalizedUserName, opt => opt.MapFrom(f => f.UserName.ToUpperInvariant()))
                .ForMember(d => d.NormalizedUserName, opt => opt.Condition(f => f.UserName != default));
            
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>()
                .ForMember(d => d.RoleClaims, opt => opt.MapFrom(f => f.RoleClaims))
                .ForMember(d => d.RoleClaims, opt => opt.Condition(f => f.RoleClaims != default))
                .ForMember(d => d.Name, opt => opt.MapFrom(f => f.Name))
                .ForMember(d => d.Name, opt => opt.Condition(f => f.Name != default))
                .ForMember(d => d.NormalizedName, opt => opt.MapFrom(f => f.Name.ToUpperInvariant()))
                .ForMember(d => d.Name, opt => opt.Condition(f => f.Name != default))
                .ForMember(d => d.ConcurrencyStamp, opt => opt.NullSubstitute(Guid.NewGuid().ToString()));
        }
    }
}
