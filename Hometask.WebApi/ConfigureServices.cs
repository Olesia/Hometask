
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;
using Hometask.Data;
using Hometask.DAL.Repositories;
using System.Reflection;
using Hometask.BLL.Services;

namespace Hometask.WebApi
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddStartupServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
            services.Configure<LiteDbOptions>(options => options.DatabaseLocation = @"CartDB.db");

            services.AddScoped<ApplicationDbContextInitialiser>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();

            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IPrintService, PrintService>();

            return services;
        }
    }
}
