using Challenge.Domain.Entities;
using Challenge.Domain.FluentValidators;
using Challenge.Domain.Interfaces;
using FluentValidation.Results;

namespace Challenge.Domain;

public class Customer : BaseEntity, ICustomerDomain
{
    public String Name { get; }
    public String Email { get; }
    public String Phone { get; }
    public String Type { get; }
    
    
    public async Task<ValidationResult> CreateAsync(Customer entity)
    {
        var entityResult = await new CustomerValidator().ValidateAsync(entity);

        if (!entityResult.IsValid)
            return entityResult;
        
        //Insert into database.

        return entityResult;
    }
}