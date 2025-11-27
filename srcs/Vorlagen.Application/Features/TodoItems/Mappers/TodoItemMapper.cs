using Vorlagen.Domain.Entities;
using Vorlagen.Shared.Features.TodoItems.Dtos;

namespace Vorlagen.Application.Features.TodoItems.Mappers;

public static class TodoItemMapper
{
    public static TodoItemDto ToDto(TodoItem todoItem) => new()
    {
        Id = todoItem.Id,
        Title = todoItem.Title,
        IsDone = todoItem.IsDone
    };

    public static List<TodoItemDto> ToDto(IEnumerable<TodoItem> todoItems) =>
        todoItems.Select(ToDto).ToList();
}
