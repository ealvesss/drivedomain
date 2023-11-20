using DriveDomain.Application;
using DriveDomain.Domain.Interfaces;
using DrivenDomain.Application.Interfaces;
using DrivenDomain.Domain;

namespace DrivenDomain.Api.Extensions;

public static class DiExtension
{
    public static void Inject(this IServiceCollection services)
    {
        services.AddTransient<ICustomerAppService, CustomerAppService>();
        services.AddTransient<ICustomerDomainService, CustomerDomainService>();
    }
}