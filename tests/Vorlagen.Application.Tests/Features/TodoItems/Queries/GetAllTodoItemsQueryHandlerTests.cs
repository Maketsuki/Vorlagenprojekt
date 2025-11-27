using Moq;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Features.TodoItems.Queries;
using Vorlagen.Domain.Entities;
using Xunit;

namespace Vorlagen.Application.Tests.Features.TodoItems.Queries;

public class GetAllTodoItemsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnAllTodoItems()
    {
        // Arrange
        var todoItems = new List<TodoItem>
        {
            new() { Id = Guid.NewGuid(), Title = "Test 1", IsDone = false },
            new() { Id = Guid.NewGuid(), Title = "Test 2", IsDone = true }
        };

        var mockRepo = new Mock<ITodoItemRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(todoItems);

        var handler = new GetAllTodoItemsQueryHandler(mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetAllTodoItemsQuery(), CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
    }
}
