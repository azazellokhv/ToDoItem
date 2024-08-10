using Microsoft.EntityFrameworkCore;
using ToDoItem.Application.Services;
using ToDoItem.DataAccess;
using ToDoItem.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoItemDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ToDoItemDbContext)));
        
    });

builder.Services.AddScoped<IToDoItemsService, ToDoItemsService>();
builder.Services.AddScoped<IToDoItemsRepository, ToDoItemsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.UseCors(x =>
{ 
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
