using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Questao5.BuildingBlocks.CrossCutting.MessageCatalogs;
using Questao5.BuildingBlocks.CrossCutting.MessageCatalogs.Interfaces;
using Questao5.BuildingBlocks.Validations;
using Questao5.Domain.Services;
using Questao5.Domain.Stores;
using Questao5.Infrastructure.Configurations.Database.Sqlite;
using Questao5.Infrastructure.Configurations.Extensions;
using Questao5.Infrastructure.Database.Movements;
using Questao5.Infrastructure.Services.Movements;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
builder.Services.AddSingleton<IDbConnection>(provider => new SqliteConnection("Data Source=database.sqlite"));

// Message Catalog
builder.Services.AddSingleton<IMessageCatalog, MessageCatalog>();

// FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Mediatr
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

// Services and repositories
builder.Services.AddScoped<IMovementCommandStore, MovementCommandStore>();
builder.Services.AddScoped<IMovementQueryStore, MovementQueryStore>();
builder.Services.AddScoped<IMovementService, MovementService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informações úteis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


