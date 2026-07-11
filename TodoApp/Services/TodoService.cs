namespace TodoApp.Services;
using TodoApp.Models;

public class TodoService : ITodoService{
    
    private readonly List<TodoItem> _todos = new (){

        new TodoItem { Id = 1, Title = "To Learn C#", IsCompleted = true },
        new TodoItem { Id = 2, Title = "To create TodoAPI", IsCompleted = false }
    };

    public Task<List<TodoItem>> GetAllAsync(){
        
        return Task.FromResult(_todos);
    }

    public Task<TodoItem?> GetByIdAsync(int id){

        var todo = _todos.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(todo);

    }

    public Task<TodoItem> CreateAsync(TodoItem todo){

        var newId = _todos.Count > 0 ? _todos.Max(t => t.Id) + 1 : 1;
        var newTodo = todo with { Id = newId };
        _todos.Add(newTodo);
        return Task.FromResult(newTodo);
    }

    public Task<TodoItem> UpdateAsync(int id, TodoItem updatedTodo){

        var existingTodo = _todos.FirstOrDefault(t => t.Id == id);
        if(existingTodo == null){
            
            return Task.FromResult<TodoItem>(null!);
        }

        var updated = updatedTodo with { Id = id};
        var index = _todos.IndexOf(existingTodo);
        _todos[index] = updated;
        return Task.FromResult(updated);
    }

    public Task<bool> DeleteAsync(int id){

        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if(todo == null){

            return Task.FromResult(false);
        }
        _todos.Remove(todo);
        return Task.FromResult(true);
    }
}