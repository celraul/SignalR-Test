using Cel.SignalR.Application.Interfaces;
using Cel.SignalR.Infra.EntityCore;
using Cel.SignalR.Infra.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cel.SignalR.Infra;

public static class ConfigureServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataBase()
            .AddSignalrServices()
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }

    private static IServiceCollection AddSignalrServices(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddScoped<IHubContext, ChatHubContext>();

        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services)
    {
        services.AddDbContext<MemoryDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb")
        );

        services.AddScoped<IMemoryDbContext, MemoryDbContext>();

        return services;
    }
}
