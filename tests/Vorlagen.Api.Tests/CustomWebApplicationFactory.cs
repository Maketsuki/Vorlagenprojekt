using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Infrastructure.Persistence;
using Vorlagen.Infrastructure.Persistence.Repositories;

namespace Vorlagen.Api.Tests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            var todoItemRepositoryDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(ITodoItemRepository));

            if (todoItemRepositoryDescriptor != null)
            {
                services.Remove(todoItemRepositoryDescriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        });
    }
}
