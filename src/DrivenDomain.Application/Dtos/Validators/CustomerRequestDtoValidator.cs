using DrivenDomain.Application.Dtos.Request;
using FluentValidation;

namespace DrivenDomain.Application.Dtos.FluentValidators;

public class CustomerDtoValidator : AbstractValidator<CustomerRequestDto>
{
    public CustomerDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
    }
}