using System.Reflection;
using ProjetoAPIEcommerce.Domain;
using System.Collections.Immutable;
using ProjetoAPIEcommerce.Controllers;
using ProjetoAPIEcommerce.Application;
using ProjetoAPIEcommerce.Infraestructure.Repository;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddOptions();
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRepository<Product>, ProductRepository>();

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

