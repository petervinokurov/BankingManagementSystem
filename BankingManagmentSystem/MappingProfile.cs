using System;
using AutoMapper;
using BankingManagmentSystem.Dto;
using BankingManagmentSystem.Entities;

namespace BankingManagmentSystem
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<BmcUser, BmsUserProjection>();
        }
    }
}
