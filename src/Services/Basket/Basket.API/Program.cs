var builder = WebApplication.CreateBuilder(args);
// Add services

var app = builder.Build();
// configure http request pipeline

app.Run();
