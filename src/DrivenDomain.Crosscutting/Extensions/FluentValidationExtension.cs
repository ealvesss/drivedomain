using DrivenDomain.Application.Dtos.FluentValidators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DrivenDomain.Infrastructure.Extensions;

public static class FluentValidationExtension
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CustomerRequestDtoValidator).Assembly);
    }
}