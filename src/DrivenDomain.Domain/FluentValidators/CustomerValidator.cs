using Challenge.Domain.Entities;
using FluentValidation;

namespace Challenge.Domain.FluentValidators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor( x => x.Name ).NotEmpty().WithMessage( "Name is required" );
        RuleFor( x => x.Email ).NotEmpty().WithMessage( "Email is required" );
        RuleFor( x => x.Phone ).NotEmpty().WithMessage( "Phone is required" );
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}