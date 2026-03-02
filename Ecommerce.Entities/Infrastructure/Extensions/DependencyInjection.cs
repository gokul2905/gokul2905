using CoreKit.Persistence.Abstractions;
using CoreKit.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Entities.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddEntitiesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(KnownString.DefaultConnection)));

        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
