using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PFClean.Contracts.Repositories;
using PFClean.Contracts.Services;
using PFClean.Infrastructure.Persistence.DataContext;
using PFClean.Infrastructure.Repositories;
using PFClean.Services;

namespace PFClean.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiV1", Version = "v1" }); });
            services.AddDbContext<DataContext>(optionsAction => 
                optionsAction.UseSqlite(configuration.GetConnectionString(("DefaultConnection")))
            );

            //services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();

            services.AddCors(corsOptions =>
                corsOptions.AddPolicy("CorsPolicy", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin())
            );

            return services;
        }
    }
}
