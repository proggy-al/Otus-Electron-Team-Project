using Swashbuckle.AspNetCore.SwaggerUI;

namespace GMS.Core.WebHost.Configurations
{
    public static class WebApplicationConfiguration
    {
        public static WebApplication Configure(WebApplicationBuilder builder)
        {
            var app = builder.Build();

            //app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    //options.SwaggerEndpoint("/swagger/v1/swagger.json", "GMS API v1");
                    //options.RoutePrefix = string.Empty;
                    //options.DocExpansion(DocExpansion.List);
                    //options.OAuthClientId("clientWebApi");
                    //options.OAuthScopeSeparator(" ");
                    //options.OAuthClientSecret("36a4d0df-d361-4c3c-a3eb-2e519d4c4391");
                });
            //}

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
