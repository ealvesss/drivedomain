using DriveDomain.Application.Services;
using DriveDomain.Domain.Interfaces;
using DrivenDomain.Application.Interfaces;
using DrivenDomain.Domain.Services;
using DrivenDomain.Infrastructure.Interfaces;
using DrivenDomain.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DrivenDomain.Infrastructure.Extensions;

public static class DiExtension
{
    public static void Inject(this IServiceCollection services)
    {
        services.AddTransient<ICustomerAppService, CustomerAppService>();
        services.AddTransient<ICustomerDomainService, CustomerDomainService>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }
}