using DrivenDomain.Application.Dtos.Request;
using DrivenDomain.Application.Dtos.Response;
using FluentValidation.Results;

namespace DrivenDomain.Application.Interfaces;

public interface ICustomerAppService
{
    Task<ValidationResult> CreateAsync(CustomerCreateRequestDto customerCreateRequestDto);
    Task<CustomerResponseBase<GetAllCustomersResponseDto>> GetAllAsync(CustomerGetAllRequestDto request);
}