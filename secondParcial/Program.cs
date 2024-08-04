using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using secondParcial.Contexto;
using secondParcial.DTOS;
using secondParcial.Repositories.Impl;
using secondParcial.Repositories.Interfaces;
using secondParcial.Servicios.Impl;
using secondParcial.Servicios.Interfaces;
using secondParcial.Validators;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IDBRepositorySocio,DBRepositorySocio>();
builder.Services.AddTransient<IDBRepositoryDeporte, DBRepositoryDeporte>();
builder.Services.AddTransient<IServicio, Servicio>();
builder.Services.AddDbContext<ClubContext>((context) =>
{
    context.UseSqlServer(builder.Configuration.GetConnectionString("UserConnectionStrings"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.WithMethods("GET" , "POST", "PUT", "DELETE");
});
app.UseAuthorization();

app.MapControllers();

app.Run();
