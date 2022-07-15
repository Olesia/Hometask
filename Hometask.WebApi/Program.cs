using Hometask.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStartupServices(builder.Configuration);
builder.Services.AddControllers();

#region API Versioning

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true; 
    x.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

#endregion



#region Swagger configurations

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

#endregion

#region Message Listener
using (var scope = app.Services.CreateScope())
{
    var listener = scope.ServiceProvider.GetRequiredService<MessageListener>();
    await listener.StartListening();
}
#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
