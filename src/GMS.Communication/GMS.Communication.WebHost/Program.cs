var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddSignalR();
app.MapGet("/", () => "Hello World!");

app.Run();
