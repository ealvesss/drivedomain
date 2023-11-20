using DrivenDomain.Domain;
using FluentValidation;

namespace DriveDomain.Domain.FluentValidators;

public class CustomerValidator : AbstractValidator<CustomerDomainService>
{
    public CustomerValidator()
    {
        RuleFor( x => x.Name ).NotEmpty().WithMessage( "Name is required" );
        RuleFor( x => x.Email ).NotEmpty().WithMessage( "Email is required" );
        RuleFor( x => x.Phone ).NotEmpty().WithMessage( "Phone is required" );
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}