
using Microsoft.Extensions.DependencyInjection;
using Vorlagen.Application.Services;

namespace Vorlagen.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITodoItemService, TodoItemService>();
        return services;
    }
}
