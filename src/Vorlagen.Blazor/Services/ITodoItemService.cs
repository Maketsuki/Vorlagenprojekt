using Vorlagen.Application.Features.TodoItems.Dtos;
using Vorlagen.Application.Features.TodoItems.Commands;

namespace Vorlagen.Blazor.Services;

public interface ITodoItemService
{
    Task<IReadOnlyList<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto> CreateAsync(CreateTodoItemCommand command);
    Task UpdateAsync(UpdateTodoItemCommand command);
    Task DeleteAsync(Guid id);
}
