using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApiTestAKS.Models;
using MinimalApiTestAKS.Services;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddTransient<ITodoItemService, TodoItemService>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<TodoDb>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.ToListAsync());
app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());
app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
        ? Results.Ok(todo)
        : Results.NotFound());
app.MapPost("/todoitems", async (Todo todo, TodoDb db) =>{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Created($"/todoitems/{todo.ID}", todo);
});
app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null && inputTodo is null) return Results.NoContent();
    todo.SetName(inputTodo.Name);
    todo.SetIsComplete(inputTodo.IsComplete);
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }
    return Results.NotFound();
});

//Tests

app.MapPost("/todotest", async (Todo d, ITodoItemService todoItemService) 
         => await todoItemService.AddTodo(d.Name));

app.Run();


public partial class Program { }