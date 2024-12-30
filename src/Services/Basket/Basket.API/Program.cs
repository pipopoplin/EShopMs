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

var app = builder.Build();

// configure http request pipeline
app.MapCarter();

app.Run();

