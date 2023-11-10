using AppTransaction.Aplication.Interfaces;
using AppTransaction.Aplication.Services;
using AppTransaction.Domain.Interfaces.Repository;
using AppTransaction.Infraestruture.Datos.Contexts;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


var configurationBuilder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = configurationBuilder.Build();

var connectionString = configuration.GetConnectionString("cnTransaction");
var host = CreateHostBuilder(args, connectionString).Build();

await host.RunAsync();
return;

static IHostBuilder CreateHostBuilder(string[] args, string connectionString) =>
        Host.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>
                {
                    var configurationBuilder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    var configuration = configurationBuilder.Build();

                    var connectionString = configuration.GetConnectionString("cnTransaction");

                    services.AddScoped<IClientService, ClientService>();
                    services.AddScoped<IClientRepository, ClientRepository>();
                    services.AddScoped<IProductService, ProductService>();
                    services.AddScoped<IProductRepository, ProductRepository>();
                    services.AddScoped<IOrderService, OrderService>();
                    services.AddScoped<IOrderRepository, OrderRepository>();
                    services.AddDbContext<TransactionContext>(options => options.UseSqlServer(connectionString));
                });


app.MapControllers();