using DrivenDomain.Application.Dtos.Request.Customer;
using FluentValidation;

namespace DrivenDomain.Application.Dtos.Validators.Customer;

public class CustomerCreateRequestDtoValidator : AbstractValidator<CustomerCreateRequestDto>
{
    public CustomerCreateRequestDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required");
        RuleFor(x => x.Document).NotEmpty().WithMessage("Document is required");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required");
    }
}