using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Interfaces;
using Portfolio.Domain.Services;
using Portfolio.Infrastructure;
using Portfolio.Infrastructure.Data;
using Portfolio.Infrastructure.Repositories;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<PortfolioDbContext>(options =>
{
    options.UseSqlServer(@"Server=DESKTOP-6M2345O;Database=PortfolioBase;User Id=Portfolio;Password=333;TrustServerCertificate=True;"); // Replace with your connection string
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHash>();  

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Настройка логгера Serilog
Serilog.Debugging.SelfLog.Enable(s => Console.WriteLine($"Internal Error with Serilog: {s}"));

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(@"C:\Users\Станислав\Desktop\Курсовая\logs\applog-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

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

Log.CloseAndFlush();