using AutoMapper;
using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Dtos.Request.Customer;
using DrivenDomain.Application.Dtos.Response;
using DrivenDomain.Application.Dtos.Response.Customer;
using DrivenDomain.Domain.Entities;

namespace DrivenDomain.Application.AutoMapper.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerCreateRequestDto>().ReverseMap();
        CreateMap<Customer, CustomerGetAllResponseDto>().ReverseMap();
        CreateMap<Customer, CustomerUpdateRequestDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateResponseDto>().ReverseMap();
    }
}