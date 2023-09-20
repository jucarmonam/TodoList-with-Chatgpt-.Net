using Microsoft.EntityFrameworkCore;
using TodoList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register your DbContext (TodoContext) with the DI container.
builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("TodoContext"), new MySqlServerVersion(new Version(8, 0, 25)));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
