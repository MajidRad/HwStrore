using HwStore.Application.Contract.Persistence;
using HwStore.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HwStore.Persistence;

public static class PersistenceServiceRegesteration
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<HwStoreDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("HwConnectionString")
        ));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
