using Airplane.Domain.Interfaces.ClientInterfaces;
using Airplane.Domain.Interfaces.DestinationInterfaces;
using Airplane.Domain.Interfaces.TravelInterfaces;
using Airplane.Infrastructure.Repositories;
using System.Reflection;
using Airplane.API.Presentation.Mappers;
using Airplane.Application.Services.ClientServices;
using Airplane.Application.Services.DestinationServices;
using Airplane.Application.Services.TravelServices;
using Airplane.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

//Connection
builder.Services.AddTransient<ConnectionContext>();
//Connection

//Repositories
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();
builder.Services.AddTransient<ITravelRepository, TravelRepository>();
//Repositories

//Mappers
builder.Services.AddTransient<ClientMapper>();
builder.Services.AddTransient<DestinationMapper>();
builder.Services.AddTransient<TravelMapper>();
builder.Services.AddTransient<ClientTravelMapper>();
//Mappers

//Services
builder.Services.AddTransient<IClientCrudService, ClientService>();
builder.Services.AddTransient<IDestinationCrudService, DestinationService>();
builder.Services.AddTransient<ITravelCrudServices, TravelService>();
builder.Services.AddTransient<ITravelClientService, TravelService>();
//Services

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