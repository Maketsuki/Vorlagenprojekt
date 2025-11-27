using Microsoft.EntityFrameworkCore;
using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Domain.Entities;
using Vorlagen.Infrastructure.Persistence;

namespace Vorlagen.Infrastructure.Persistence.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly AppDbContext _context;

    public TodoItemRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<TodoItem>> GetAllAsync() => await _context.TodoItems.ToListAsync();

    public async Task<TodoItem> GetByIdAsync(Guid id) => await _context.TodoItems.FindAsync(id);

    public async Task AddAsync(TodoItem todoItem)
    {
        await _context.TodoItems.AddAsync(todoItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem todoItem)
    {
        _context.Entry(todoItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoItem todoItem)
    {
        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();
    }
}
