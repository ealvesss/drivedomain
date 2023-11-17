using Challenge.Application.Dtos.FluentValidators;
using FluentValidation;

namespace Challenge.Api.Extensions;

public static class FluentValidationExtension
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CustomerDtoValidator).Assembly);
    }
}