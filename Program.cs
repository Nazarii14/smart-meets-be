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
}

var app = builder.Build();

app.Run();