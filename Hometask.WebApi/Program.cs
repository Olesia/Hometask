using Hometask.BLL.Mappings;
using Hometask.BLL.Services;
using Hometask.Common.Interfaces;
using Hometask.DAL.Entities;
using Hometask.DAL.Repositories;
using Hometask.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
builder.Services.Configure<LiteDbOptions>(options => options.DatabaseLocation = @"CartDB.db");

builder.Services.AddScoped<ApplicationDbContextInitialiser>();

builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddTransient<IRepository<CartItem>, Repository<CartItem>>();

builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IPrintService, PrintService>();


builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true; 
    //x.ApiVersionReader = new QueryStringApiVersionReader("api-version");
    // x.ApiVersionReader = new HeaderApiVersionReader("api-version");
    x.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cart API. V1",
        Version = "v1",
        Description = "An ASP.NET Core Web API for managing Cart items",
        TermsOfService = new Uri("https://example.com/terms"),
    });

    options.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "Cart API. V2",
        Version = "v2",
        Description = "An ASP.NET Core Web API for managing Cart items",
        TermsOfService = new Uri("https://example.com/terms"),
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", "Cart API.V1");
        options.SwaggerEndpoint($"/swagger/v2/swagger.json", "Cart API. V2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
