using Vorlagen.Domain.Entities;

namespace Vorlagen.Application.Contracts.Persistence;

public interface ITodoItemRepository
{
    Task<IReadOnlyList<TodoItem>> GetAllAsync();
    Task<TodoItem> GetByIdAsync(Guid id);
    Task AddAsync(TodoItem todoItem);
    Task UpdateAsync(TodoItem todoItem);
    Task DeleteAsync(TodoItem todoItem);
}
