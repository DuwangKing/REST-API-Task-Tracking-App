using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Services;
using Xunit;

namespace TodoApp.Tests;

public class TodoServiceTests
{
    private AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        return new AppDbContext(options);
    }

[Fact]
public async Task CreateAsync_ShouldAssignNewId()
{
    var context = CreateInMemoryContext();
    var service = new TodoService(context);
    var newTodo = new TodoItem { Title = "Buy milk", IsCompleted = false };

    var result = await service.CreateAsync(newTodo);

    Assert.NotEqual(0, result.Id);
    Assert.Equal("Buy milk", result.Title);
}

[Fact]
public async Task GetAllAsync_ShouldReturnAllItems()
{
    var context = CreateInMemoryContext();
    var service = new TodoService(context);
    
    context.Todos.Add(new TodoItem { Title = "Task 1"});
    context.Todos.Add(new TodoItem { Title = "Task 2"});

    await context.SaveChangesAsync();

    var result = await service.GetAllAsync();

    Assert.Equal(2, result.Count);
}

[Fact]
public async Task DeleteAsync_WhenItemExists_ShouldReturnTrue()
{
    var context = CreateInMemoryContext();
    var service = new TodoService(context);

    var todo = new TodoItem { Title = "Delete me" };
    context.Todos.Add(todo);
    await context.SaveChangesAsync();

    var result = await service.DeleteAsync(todo.Id);

    Assert.True(result);

    Assert.Empty(context.Todos);

}

[Fact]
public async Task DeleteAsync_WhenItemNotFound_ShouldReturnFalse()
{
    var context = CreateInMemoryContext();
    var service = new TodoService(context);

    var result = await service.DeleteAsync(999);

    Assert.False(result);
}

}