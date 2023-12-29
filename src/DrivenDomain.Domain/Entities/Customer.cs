using DrivenDomain.Domain.Validators;
using FluentValidation.Results;

namespace DrivenDomain.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Document { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }


    public async Task<ValidationResult> CheckDataBeforeCreate(Customer entity)
    {
        var entityResult = await new CustomerValidator().ValidateAsync(entity);

        if (!entityResult.IsValid)
            return entityResult;

        return entityResult;
    }
}