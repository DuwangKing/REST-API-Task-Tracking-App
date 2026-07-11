var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello, world!");

app.MapGet("/hello/{name}", (string name) => $"Hello, {name}!");

app.MapGet("/sum/{a}/{b}", (int a, int b) => $"Sum = {a + b}");

app.Run();