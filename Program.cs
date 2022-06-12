using Microsoft.EntityFrameworkCore;
using TodoApi.Contexts;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<TodoTaskContext>(opt => opt.UseSqlServer(connString));
builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // app.UseDefaultFiles();
    // app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
