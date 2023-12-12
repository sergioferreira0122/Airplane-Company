using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using webAPI.Application.Mappers;
using webAPI.Application.Services;
using webAPI.Infrastructure;
using webAPI.Infrastructure.Repositories;
using webAPI.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<ConnectionContext, ConnectionContext>();

builder.Services.AddTransient<IClientRepository, ClientRepository>();

builder.Services.AddTransient<IClientMapper, ClientMapper>();

builder.Services.AddTransient<IClientCRUDService, ClientService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseAuthorization();

app.MapControllers();

app.Run();

