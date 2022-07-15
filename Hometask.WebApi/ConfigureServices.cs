
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;
using Hometask.Data;
using Hometask.DAL.Repositories;
using System.Reflection;
using Hometask.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hometask.WebApi
{
    /// <summary>
    /// Services configuration
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Startup configurations extension method
        /// </summary>
        /// <param name="services"> This services</param>
        /// <returns> This services </returns>
        public static IServiceCollection AddStartupServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
            services.Configure<LiteDbOptions>(options => options.DatabaseLocation = @"CartDB.db");

            services.AddScoped<ApplicationDbContextInitialiser>();
            
            services.AddAutoMapper(typeof(BLL.Mappings.AutoMapping));

            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();

            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IPrintService, PrintService>();
            services.AddSingleton(x => new MessageListener(x.GetRequiredService<ICartService>(), configuration));
            return services;
        }
    }
}
