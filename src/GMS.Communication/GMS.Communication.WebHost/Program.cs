using GMS.Communication.WebHost.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapHub<ChatHub>($"/chatHub"));

app.Run();
