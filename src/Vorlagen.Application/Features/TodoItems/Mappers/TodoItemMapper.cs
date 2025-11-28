using Vorlagen.Application.Features.TodoItems.Dtos;
using Vorlagen.Domain.Entities;

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
