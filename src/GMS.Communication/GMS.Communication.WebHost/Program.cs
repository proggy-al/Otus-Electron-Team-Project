using GMS.Communication.WebHost.Hubs;

// TODO добавить реалзицию Stratup для разделения наполнения IoC и Pipeline
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapHub<ChatHub>($"/chatHub");
app.MapControllers();
app.Run();
