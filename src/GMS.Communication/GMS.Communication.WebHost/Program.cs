using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.SignalR;

// TODO добавить реалзицию Stratup для разделения наполнения IoC и Pipeline
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IUserIdProvider, MyUserProvider>();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCustomJWTAuthentification();    


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
//}

//app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ChatHub>($"/chatHub");
app.Run();
