using System.Net.Http.Json;
using Vorlagen.Application.Dtos;

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

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/todo-items", dto);
        return await response.Content.ReadFromJsonAsync<TodoItemDto>();
    }

    public async Task UpdateAsync(UpdateTodoItemDto dto) =>
        await _httpClient.PutAsJsonAsync($"api/todo-items/{dto.Id}", dto);

    public async Task DeleteAsync(Guid id) =>
        await _httpClient.DeleteAsync($"api/todo-items/{id}");
}
