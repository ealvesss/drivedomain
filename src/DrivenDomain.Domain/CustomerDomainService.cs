using DriveDomain.Domain.FluentValidators;
using DriveDomain.Domain.Interfaces;
using DrivenDomain.Domain.Entities;
using FluentValidation.Results;

namespace DrivenDomain.Domain;

public class CustomerDomainService : BaseEntity, ICustomerDomainService
{
    public String Name { get; }
    public String Email { get; }
    public String Phone { get; }
    public String Type { get; }
    
    
    public async Task<ValidationResult> CreateAsync(CustomerDomainService entity)
    {
        var entityResult = await new CustomerValidator().ValidateAsync(entity);

        if (!entityResult.IsValid)
            return entityResult;
        
        //Insert into database.

        return entityResult;
    }
}