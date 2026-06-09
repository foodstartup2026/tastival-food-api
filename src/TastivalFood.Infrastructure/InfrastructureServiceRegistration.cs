using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TastivalFood.Application.Common.Interfaces;
using TastivalFood.Application.Common.Models;
using TastivalFood.Infrastructure.Persistence;
using TastivalFood.Infrastructure.Repositories;
using TastivalFood.Infrastructure.Services;

namespace TastivalFood.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddDbContext<TastivalFoodDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRestaurantTypeRepository, RestaurantTypeRepository>();
            services.AddScoped<ITokenService, JwtTokenService>();
            return services;
        }
    }
}
