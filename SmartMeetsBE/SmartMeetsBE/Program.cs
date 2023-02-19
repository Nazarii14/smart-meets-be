using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

using var connection = new MySqlConnection(builder.Configuration.GetConnectionString("Default"));

await connection.OpenAsync();

using var command = new MySqlCommand("SELECT field FROM table;", connection);
using var reader = await command.ExecuteReaderAsync();
while (await reader.ReadAsync())
{
    var value = reader.GetValue(0);
    // do something with 'value'
}
//builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

//app.MapGet("/todoitems", async (TodoDb SmartMeets) =>
//    await SmartMeets.Todos.ToListAsync());

//app.MapGet("/todoitems/complete", async (TodoDb SmartMeets) =>
//    await SmartMeets.Todos.Where(t => t.IsComplete).ToListAsync());

//app.MapGet("/todoitems/{id}", async (int id, TodoDb SmartMeets) =>
//    await SmartMeets.Todos.FindAsync(id)
//        is Todo todo
//            ? Results.Ok(todo)
//            : Results.NotFound());

//app.MapPost("/todoitems", async (Todo todo, TodoDb SmartMeets) =>
//{
//    SmartMeets.Todos.Add(todo);
//    await SmartMeets.SaveChangesAsync();

//    return Results.Created($"/todoitems/{todo.Id}", todo);
//});

//app.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb SmartMeets) =>
//{
//    var todo = await SmartMeets.Todos.FindAsync(id);

//    if (todo is null) return Results.NotFound();

//    todo.Name = inputTodo.Name;
//    todo.IsComplete = inputTodo.IsComplete;

//    await SmartMeets.SaveChangesAsync();

//    return Results.NoContent();
//});

//app.MapDelete("/todoitems/{id}", async (int id, TodoDb SmartMeets) =>
//{
//    if (await SmartMeets.Todos.FindAsync(id) is Todo todo)
//    {
//        SmartMeets.Todos.Remove(todo);
//        await SmartMeets.SaveChangesAsync();
//        return Results.Ok(todo);
//    }

//    return Results.NotFound();
//});

app.Run();