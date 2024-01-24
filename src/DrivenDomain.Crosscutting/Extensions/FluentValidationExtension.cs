using DrivenDomain.Application.Dtos.Validators.Customer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DrivenDomain.Infrastructure.Extensions;

public static class FluentValidationExtension
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CustomerCreateRequestDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(CustomerGetAllRequestDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(CustomerUpdateRequestDtoValidator).Assembly);
    }
}