using DependencyStore;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();
builder.Services.AddScoped(x 
    => new SqlConnection("CONN_STRING"));

//Caso não haja camada de interface, pode ser usado dessa maneira:
//builder.Services.AddTransient<CustomerRepository>();
// builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
// builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
// builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();