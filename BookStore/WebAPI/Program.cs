using Business.Validations;
using Core.Model;
using DataAccess.DependencyResolver;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependency();

builder.Services.AddSingleton<IValidator<Genre>, GenreValidator>();
builder.Services.AddSingleton<IValidator<Author>, AuthorValidator>();
builder.Services.AddSingleton<IValidator<Book>, BookValidator>();
builder.Services.AddSingleton<IValidator<User>, UserValidator>();
builder.Services.AddSingleton<IValidator<Order>, OrderValidator>();

builder.Services.AddControllersWithViews().AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblyContaining<Program>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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