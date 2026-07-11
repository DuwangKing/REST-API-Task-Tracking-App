namespace TodoApp.Services;
using TodoApp.Models;

public interface ITodoService
{
    Task<List<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    Task<TodoItem> CreateAsync(TodoItem todo);
    Task<TodoItem> UpdateAsync(int id, TodoItem todo);
    Task<bool> DeleteAsync(int id);
}