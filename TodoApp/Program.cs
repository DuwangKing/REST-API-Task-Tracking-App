using TodoApp.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var todos = new List<TodoItem>{
    new TodoItem {Id = 1, Title = "To Learn C#", IsCompleted = true},
    new TodoItem {Id = 2, Title = "To create TodoAPI", IsCompleted = false}
};

app.MapGet("/api/todos", () => todos);

app.MapGet("/api/todos/{id}", (int id) => {

    var foundTodo = todos.FirstOrDefault(t => t.Id == id);

    if(foundTodo != null){
        return Results.Ok(foundTodo);
    }

    else{
        return Results.NotFound();
    }
});

app.MapPost("/api/todos", (TodoItem newTodo) =>{

    var newId = todos.Count > 0 ? todos.Max(t => t.Id) + 1 : 1;

    var todoWithId = newTodo with { Id = newId };

    todos.Add(todoWithId);

    return Results.Created($"/api/todos/{todoWithId.Id}", todoWithId);
});

app.MapPut("/api/todos/{id}", (int id, TodoItem updatedTodo) => {

    var existingTodo = todos.FirstOrDefault(t => t.Id == id);

    if(existingTodo == null){
        return Results.NotFound();
    }

    var updated = updatedTodo with { Id = id };

    var index =  todos.IndexOf(existingTodo);

    todos[index] = updated;

    return Results.Ok(updated);
});

app.MapDelete("/api/todos/{id}", (int id) =>{
    var todo = todos.FirstOrDefault(t => t.Id == id);

    if(todo == null){
        return Results.NotFound();
    }

    todos.Remove(todo);

    return Results.NoContent();
});

app.Run();