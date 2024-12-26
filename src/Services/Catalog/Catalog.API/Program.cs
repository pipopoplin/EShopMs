using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Add services
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssembly(assembly);
    conf.AddOpenBehavior(typeof(VailidationBehaviors<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions();

var app = builder.Build();

// configure http request pipeline
app.MapCarter();

app.Run();
