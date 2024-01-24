using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrivenDomain.Application.Dtos.Request.Customer;
using FluentValidation;

namespace DrivenDomain.Application.Dtos.Validators.Customer
{
    public class CustomerGetAllRequestDtoValidator : AbstractValidator<CustomerGetAllRequestDto>
    {
        public CustomerGetAllRequestDtoValidator()
        {
            RuleFor(x => x.Page).NotEmpty().WithMessage("Page is required").GreaterThan(0);
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("PageSize is required");
        }
    }
}