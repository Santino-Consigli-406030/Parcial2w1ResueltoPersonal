using Microsoft.EntityFrameworkCore;
using secondParcial.Contexto;
using secondParcial.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IDBRepositoryClub,DBRepositoryClub>();

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