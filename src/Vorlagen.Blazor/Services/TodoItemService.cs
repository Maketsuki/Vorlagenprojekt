using System.Net.Http.Json;
using Vorlagen.Shared.Features.TodoItems.Commands;
using Vorlagen.Shared.Features.TodoItems.Dtos;

namespace Vorlagen.Blazor.Services;

public class TodoItemService : ITodoItemService
{
    private readonly HttpClient _httpClient;

    public TodoItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyList<TodoItemDto>> GetAllAsync() =>
        await _httpClient.GetFromJsonAsync<IReadOnlyList<TodoItemDto>>("api/todo-items");

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemCommand command)
    {
        var response = await _httpClient.PostAsJsonAsync("api/todo-items", command);
        return await response.Content.ReadFromJsonAsync<TodoItemDto>();
    }

    public async Task UpdateAsync(UpdateTodoItemCommand command) =>
        await _httpClient.PutAsJsonAsync($"api/todo-items/{command.Id}", command);

    public async Task DeleteAsync(Guid id) =>
        await _httpClient.DeleteAsync($"api/todo-items/{id}");
}
