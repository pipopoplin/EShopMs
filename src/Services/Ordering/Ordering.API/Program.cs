var builder = WebApplication.CreateBuilder(args);

// add builder
// Add services
var assembly = typeof(Program).Assembly;

var services = builder.Services;

var app = builder.Build();

// configure http request pieline


app.Run();
