using Microsoft.EntityFrameworkCore;
using TodoApp.Models;
using TodoApp.Data;

namespace TodoApp.Services;

public class TodoService : ITodoService{
    
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context){
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllAsync(){
        
        return await _context.Todos.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id){

        return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

    }

    public async Task<TodoItem> CreateAsync(TodoItem todo){

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<TodoItem> UpdateAsync(int id, TodoItem updatedTodo){

        var existingTodo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if(existingTodo == null){
            
            return null!;
        }

        existingTodo.Title = updatedTodo.Title;
        existingTodo.IsCompleted = updatedTodo.IsCompleted;

        await _context.SaveChangesAsync();
        return existingTodo;
    }

    public async Task<bool> DeleteAsync(int id){

        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
        if(todo == null){

            return false;
        }
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return true;
    }
}