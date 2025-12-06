using Vorlagen.Application.Dtos;

namespace Vorlagen.Blazor.Services;

public interface ITodoItemService
{
    Task<IReadOnlyList<TodoItemDto>> GetAllAsync();
    Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto);
    Task UpdateAsync(UpdateTodoItemDto dto);
    Task DeleteAsync(Guid id);
}
