using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

using var connection = new MySqlConnection(builder.Configuration.GetConnectionString("Default"));
await connection.OpenAsync();

var app = builder.Build();

app.Run();