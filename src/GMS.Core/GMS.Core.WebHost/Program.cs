var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.ServiceConfiguration;

app.MapGet("/", () => "Hello World!");

app.Run();
