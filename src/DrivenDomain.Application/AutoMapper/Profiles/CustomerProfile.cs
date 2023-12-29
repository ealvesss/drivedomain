using AutoMapper;
using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Dtos.Response;
using DrivenDomain.Domain.Entities;

namespace DrivenDomain.Application.AutoMapper.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerCreateRequestDto>().ReverseMap();
        CreateMap<Customer, GetAllCustomersResponseDto>().ReverseMap();
    }
}