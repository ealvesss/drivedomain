using DrivenDomain.Application.Interfaces;
using DrivenDomain.Application.Services;
using DrivenDomain.Domain.Interfaces;
using DrivenDomain.Domain.Services;
using DrivenDomain.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DrivenDomain.Crosscutting.Extensions;

public static class DependencyInjectionExtension
{
    public static void Inject(this IServiceCollection services)
    {
        services.AddTransient<ICustomerAppService, CustomerAppService>();
        services.AddTransient<ICustomerDomainService, CustomerDomainService>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
    }
}