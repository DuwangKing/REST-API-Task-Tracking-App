namespace TodoApp.Models;

public record TodoItem{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
}