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
            CreateMap<BmsUser, BmsUserProjection>();
            CreateMap<BmsRole, BmsRoleProjection>();
        }
    }
}
