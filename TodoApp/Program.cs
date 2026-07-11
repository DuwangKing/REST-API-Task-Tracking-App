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

app.Run();