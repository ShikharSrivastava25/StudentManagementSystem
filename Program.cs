using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem;
using StudentManagementSystem.Behavior;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("StudentDB"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var db = services.GetRequiredService<AppDbContext>();

    db.Database.EnsureCreated();

    if (!db.Students.Any()) {
        db.Students.AddRange(
            new Student { Id = 1, Name = "John Doe", Age = 20 },
            new Student { Id = 2, Name = "Sarah Khan", Age = 22 },
            new Student { Id = 3, Name = "Ravi Patel", Age = 19 }
        );
        db.SaveChanges();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
