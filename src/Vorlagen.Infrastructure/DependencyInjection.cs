using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Infrastructure.Persistence;
using Vorlagen.Infrastructure.Persistence.Repositories;

namespace Vorlagen.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres")
                             ?? throw new InvalidOperationException("Postgres connection string not configured.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ITodoItemRepository, TodoItemRepository>();

        return services;
    }
}
