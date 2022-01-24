using PFClean.API.Extensions;
using PFClean.Contracts.Services;
using PFClean.Services;

namespace PFClean.API
{
    public class Startup
    {
        // We have a configuration (obiusly)
        private readonly IConfiguration configuration;
        // Here we inject the configuration as a dependency
        public Startup(IConfiguration config) => configuration = config;
        // Here we configure the services
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            //services.AddHttpClient();
            services.AddApplicationServices(configuration);
            //services.AddScoped<ICarService, CarService>();
            //services.AddTransient<ICarService, CarService>();
        }
        
        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment) 
        {

            if (environment.IsDevelopment())
            { 
                application.UseSwagger();
                application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","WebAPIV1 v1"));
            }
            
            application.UseRouting();
            application.UseCors("CorsPolicy");
            //application.UseAuthorization();
            application.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
