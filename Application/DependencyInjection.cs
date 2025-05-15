using Application.Services;
using Application.ServicesInterfaces;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IPersonWithPeselPerson, ServicePersonWithPesel>();
        services.AddScoped<IServiceSimplePerson, ServiceSimplePerson>();
        services.AddScoped<IService, BaseGenericService>();
        return services;
    }
}
