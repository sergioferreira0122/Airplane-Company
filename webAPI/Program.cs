using System.Reflection;
using webAPI.Application.Mappers;
using webAPI.Application.Services.ClientServices;
using webAPI.Application.Services.DestinationServices;
using webAPI.Application.Services.TravelServices;
using webAPI.Infrastructure;
using webAPI.Infrastructure.Repositories.ClientRepository;
using webAPI.Infrastructure.Repositories.DestinationRepository;
using webAPI.Infrastructure.Repositories.TravelRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

//Connection
builder.Services.AddTransient<ConnectionContext, ConnectionContext>();
//Connection

//Repositories
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IDestinationRepository, DestinationRepository>();
builder.Services.AddTransient<ITravelRepository, TravelRepository>();
//Repositories

//Mappers
builder.Services.AddTransient<ClientMapper, ClientMapper>();
builder.Services.AddTransient<DestinationMapper, DestinationMapper>();
builder.Services.AddTransient<TravelMapper, TravelMapper>();
builder.Services.AddTransient<ClientTravelMapper, ClientTravelMapper>();
//Mappers

//Services
builder.Services.AddTransient<IClientCRUDService, ClientService>();
builder.Services.AddTransient<IDestinationCRUDService, DestinationService>();
builder.Services.AddTransient<ITravelCRUDServices, TravelService>();
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