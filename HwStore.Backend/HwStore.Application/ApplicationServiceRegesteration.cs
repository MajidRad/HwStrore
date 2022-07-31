using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HwStore.Application;

public static class ApplicationServiceRegesteration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<BasketAccessor>();

        return services;
    }
}
