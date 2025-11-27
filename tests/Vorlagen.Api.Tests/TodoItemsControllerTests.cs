using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Vorlagen.Application.Features.TodoItems.Dtos;
using Vorlagen.Domain.Entities;
using Vorlagen.Infrastructure.Persistence;
using Xunit;

namespace Vorlagen.Api.Tests;

public class TodoItemsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public TodoItemsControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        var client = _factory.CreateClient();
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.TodoItems.Add(new TodoItem { Title = "Test Item" });
        await context.SaveChangesAsync();

        // Act
        var response = await client.GetAsync("/api/todo-items");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType.ToString());

        var dtos = await response.Content.ReadFromJsonAsync<IReadOnlyList<TodoItemDto>>();
        Assert.Single(dtos);
    }
}
