using Challenge.Application;
using Challenge.Application.Interfaces;

namespace Challenge.Api.Extensions;

public static class DiExtension
{
    public static void Inject(this IServiceCollection services)
    {
        services.AddTransient<ICustomerApplication, CustomerApplication>();
    }
}