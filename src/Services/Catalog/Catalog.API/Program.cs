using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services
var assembly = typeof(Program).Assembly;

var services = builder.Services;

services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(assembly);
    conf.AddOpenBehavior(typeof(VailidationBehavior<,>));
    conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

services.AddValidatorsFromAssembly(assembly);

services.AddCarter();

services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions();

if(builder.Environment.IsDevelopment())
    services.InitializeMartenWith<CatalogInitialData>();

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
