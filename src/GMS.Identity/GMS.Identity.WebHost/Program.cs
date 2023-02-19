using GMS.Identity.WebHost;
using Microsoft.AspNetCore.Builder;

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

builder.Configuration.AddJsonFile("identitysettings.json");
builder.Configuration.AddJsonFile("swaggersettings.json");
builder.Services.AddSignalR();

Registration.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();   // ���������� middleware �������������� 

app.UseAuthorization();   // ���������� middleware ����������� 

app.MapControllers();

app.Run();