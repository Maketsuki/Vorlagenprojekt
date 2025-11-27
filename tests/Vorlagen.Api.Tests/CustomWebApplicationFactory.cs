using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Infrastructure.Persistence;
using Vorlagen.Infrastructure.Persistence.Repositories;

namespace Vorlagen.Api.Tests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<AppDbContext>));
            services.RemoveAll(typeof(DbContextOptions));
            services.RemoveAll(typeof(AppDbContext));

            var todoItemRepositoryDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(ITodoItemRepository));

            if (todoItemRepositoryDescriptor != null)
            {
                services.Remove(todoItemRepositoryDescriptor);
            }

            // Manually register the options and context to ensure no Npgsql traces remain
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("InMemoryDbForTesting");

            services.AddScoped<DbContextOptions<AppDbContext>>(sp => optionsBuilder.Options);
            services.AddScoped<DbContextOptions>(sp => optionsBuilder.Options);
            services.AddScoped<AppDbContext>(sp => new AppDbContext(optionsBuilder.Options));

            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
        });
    }
}
