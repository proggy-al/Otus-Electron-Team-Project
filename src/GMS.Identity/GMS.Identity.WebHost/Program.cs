using GMS.Identity.WebHost;
using GMS.Identity.WebHost.Configuration;
using Microsoft.AspNetCore.Builder;
using System.Threading.RateLimiting;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();   //SetIsOriginAllowed(x=>true).AllowCredentials()
                      });
});



builder.Configuration.AddJsonFile("swaggersettings.json");

Registration.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
    
//}

//app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();   // добавление middleware аутентификации 

app.UseAuthorization();   // добавление middleware авторизации 

app.MapControllers();

app.Run();
