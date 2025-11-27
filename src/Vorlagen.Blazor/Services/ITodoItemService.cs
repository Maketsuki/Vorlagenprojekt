using Vorlagen.Application.Features.TodoItems.Dtos;

namespace Vorlagen.Blazor.Services;

public interface ITodoItemService
{
    Task<IReadOnlyList<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto> CreateAsync(CreateTodoItemCommand command);
    Task UpdateAsync(UpdateTodoItemCommand command);
    Task DeleteAsync(Guid id);
}
