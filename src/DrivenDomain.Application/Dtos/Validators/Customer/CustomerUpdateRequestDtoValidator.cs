using DrivenDomain.Application.Dtos.Request.Customer;
using FluentValidation;

namespace DrivenDomain.Application.Dtos.Validators.Customer
{
    public class CustomerUpdateRequestDtoValidator : AbstractValidator<CustomerUpdateRequestDto>
    {
        public CustomerUpdateRequestDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
        }
        
    }
}