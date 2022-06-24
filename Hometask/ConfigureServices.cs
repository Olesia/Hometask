
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;
using Hometask.Data;
using Hometask.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Hometask.BLL.Services;
using AutoMapper;
using Hometask.BLL.Dto;

namespace Hometask
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddStartupServices(this IServiceCollection services)
        {
            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
            services.Configure<LiteDbOptions>(options => options.DatabaseLocation = @"CartDB.db");

            services.AddScoped<ApplicationDbContextInitialiser>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartItemSevice, CartItemService>();
            services.AddScoped<IPrintService, PrintService>();





            return services;
        }
    }
}
