using Microsoft.EntityFrameworkCore;
using TodoApi.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<TodoTaskContext>(opt => opt.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// scoped service goes here

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
