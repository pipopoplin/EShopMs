using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
var services = builder.Services;

// Add services
services.AddCarter();
services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(assembly);
    conf.AddOpenBehavior(typeof(VailidationBehavior<,>));
    conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DataBase")!);
    opt.Schema.For<ShopingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

services.AddScoped<IBasketRepository, BasketRepository>();

services.AddExceptionHandler<CustomExceptionHandler>();

services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("DataBase")!);

var app = builder.Build();

// configure http request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });

app.MapHealthChecks("/health",
    new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

app.Run();

