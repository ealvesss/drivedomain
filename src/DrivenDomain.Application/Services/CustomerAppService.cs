using DriveDomain.Domain.Interfaces;
using DrivenDomain.Application.Dtos;
using DrivenDomain.Application.Dtos.Builders;
using DrivenDomain.Application.Dtos.FluentValidators;
using DrivenDomain.Application.Interfaces;
using DrivenDomain.Crosscutting.Common.BuilderGeneric;
using FluentValidation.Results;

namespace DriveDomain.Application;

public class CustomerAppService : ICustomerAppService
{
    private readonly Domain.Interfaces.ICustomerDomainService _customerDomainService;
    public CustomerAppService(Domain.Interfaces.ICustomerDomainService customerDomainService)
    {
        _customerDomainService = customerDomainService;
    }

    //public async Task<ValidationResult> CreateAsync(CustomerDto dto)
    public async Task<BuildResult<CustomerDto>> CreateAsync(CustomerDto dto)
    {
        var customer = CustomerDtoBuilder.Create()
            .WithName(dto.Name)
            .WithEmail(dto.Email)
            .WithPhone(dto.Phone)
            .Build();

        //var result = await new CustomerDtoValidator().ValidateAsync(dto);
        
        //if(!result.IsValid)
        //    return await Task.FromResult(result);
        
        //var resultDomain = await _customerDomain.CreateAsync(result);
        
        return await Task.FromResult(customer);
    }
}