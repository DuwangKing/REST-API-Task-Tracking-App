using TodoApp.Models;
using TodoApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Get all Todo's
app.MapGet("api/todos", async (ITodoService todoService) =>{

    var todos = await todoService.GetAllAsync();
    return todos;
}).WithTags("Todos");

//Get Todo by Id
app.MapGet("api/todos/{id}", async (int id, ITodoService todoService) =>{

    var todo = await todoService.GetByIdAsync(id);

    if(todo == null){
        
        return Results.NotFound();
    }
    return Results.Ok(todo);
}).WithTags("Todos");

//Create new Todo
app.MapPost("api/todos", async (TodoItem newTodo, ITodoService todoService) => {

    var createdTodo = await todoService.CreateAsync(newTodo);
    return Results.Created($"/api/todos/{createdTodo.Id}", createdTodo);
}).WithTags("Todos");

//Update existing Todo
app.MapPut("api/todos/{id}", async (int id, TodoItem updatedTodo, ITodoService todoService) =>{

    var updated = await todoService.UpdateAsync(id, updatedTodo);

    if(updated == null){
        return Results.NotFound();
    }
    return Results.Ok(updated);
}).WithTags("Todos");


//Delete existing Todo

app.MapDelete("/api/todos/{id}", async (int id, ITodoService todoService) => {

    var deleted = await todoService.DeleteAsync(id);

    if(!deleted){
        return Results.NotFound();
    }

    return Results.NoContent();
}).WithTags("Todos");

app.Run();