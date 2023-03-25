using GMS.Communication.DataAccess.Context;
using GMS.Communication.WebHost.Hubs;
using GMS.Communication.WebHost.Models;
using JWTAuthManager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace GMS.Communication.WebHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GmsMessagesDb>(options =>
            {
                options.UseSqlite(
                    "Data Source=GmsMessages.db",
                    x => x.MigrationsAssembly("GMS.Communication.DataAccess.Sqlite")
                    );
            });
            services.AddSingleton<IUserIdProvider, MyUserProvider>();
            services.AddSignalR();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCustomJWTAuthentification();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>($"/chatHub");
            });
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
