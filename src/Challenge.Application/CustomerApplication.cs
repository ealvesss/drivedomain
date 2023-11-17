using Challenge.Application.Dtos;
using Challenge.Application.Dtos.FluentValidators;
using Challenge.Application.Interfaces;
using FluentValidation.Results;
namespace Challenge.Application;

public class CustomerApplication : ICustomerApplication
{
    public CustomerApplication()
    {
        
    }

    //public async Task<BuildResult<CustomerDto>> Insert(CustomerDto dto)
    public async Task<ValidationResult> CreateAsync(CustomerDto dto)
    {
        // var customer = CustomerDtoBuilder.Create()
        //     .WithName(dto.Name)
        //     .WithEmail(dto.Email)
        //     .WithPhone(dto.Phone)
        //     .Build();

        var result = await new CustomerDtoValidator().ValidateAsync(dto);
        
        if(!result.IsValid)
            return await Task.FromResult(result);
        
        return await Task.FromResult(result);
    }
}