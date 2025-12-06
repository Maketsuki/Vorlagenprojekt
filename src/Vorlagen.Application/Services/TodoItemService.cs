using Vorlagen.Application.Contracts.Persistence;
using Vorlagen.Application.Dtos;
using Vorlagen.Domain.Entities;

namespace Vorlagen.Application.Services;

public class TodoItemService : ITodoItemService
{
    private readonly ITodoItemRepository _repository;

    public TodoItemService(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<TodoItemDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();
        return items.Select(x => new TodoItemDto
        {
            Id = x.Id,
            Title = x.Title,
            IsDone = x.IsDone
        }).ToList();
    }

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto)
    {
        var item = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            IsDone = false
        };

        await _repository.AddAsync(item);

        return new TodoItemDto
        {
            Id = item.Id,
            Title = item.Title,
            IsDone = item.IsDone
        };
    }

    public async Task UpdateAsync(UpdateTodoItemDto dto)
    {
        var item = await _repository.GetByIdAsync(dto.Id);
        if (item == null)
        {
            // In a real app, we might throw a NotFoundException here
            return;
        }

        item.Title = dto.Title;
        item.IsDone = dto.IsDone;

        await _repository.UpdateAsync(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item != null)
        {
            await _repository.DeleteAsync(item);
        }
    }
}
