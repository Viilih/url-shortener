using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Url.Domain.Interfaces;
using Url.Infrastructure.Clock;
using Url.Infrastructure.Common;
using Url.Infrastructure.Common.Interfaces;
using Url.Infrastructure.Repositories;

namespace Url.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        var connectionString = configuration.GetConnectionString("Database") ??
                               throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IUrlRepository, UrlRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}