using AutoMapper;
using DrivenDomain.Application.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace DrivenDomain.Infrastructure.Extensions;

public static class AutoMapperExtension
{
    public static void AddProfile(this IServiceCollection config)
    {
        //add all profiles
        config.AddAutoMapper(typeof(CustomerProfile));
        
    }
}