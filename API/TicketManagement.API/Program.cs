#region Using Statements
global using TicketManagement.Application;
using TicketManagement.DataPersistence;
using TicketManagement.Infrastructure;
using TicketManagement.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using TicketManagement.Api.Utility;
using TicketManagement.API.Middleware;
using TicketManagement.Application.Interfaces;
using TicketManagement.Api.Services;
using System.Text.Json.Serialization;
#endregion

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices : Add services to the container.

#region Add Serilog as a logging provider 
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
#endregion

#region  Add Application, DataPersistence and Infrastructure Libraries
builder.Services.AddDataPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
#endregion

builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
            );

builder.Services.AddEndpointsApiExplorer();

#region  Enable CORS  (Cross Origin Resource Sharing)
const string  _policyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion

#region configuring Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ticket Management API",
        Description = "For Test Admin Functionalities:" +
        "\r\n\r\n\t\"email\":\"Admin@test.com\",\r\r\n\t\"password\":\"Admin123*\"" +
        "\r\n\r\tPlease signup with valid email to recieve new mail after create new event(feature availbale only for admins)",

    });
    
    #region support JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                    Enter 'Bearer' [space] and then your token in the text input below.
                    \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });
    #endregion

    #region support csv files
    c.OperationFilter<FileResultContentTypeOperationFilter>(); 
    #endregion
}); 
#endregion

#endregion

var app = builder.Build();

#region Configure: Configure the HTTP request pipeline (Middleware pipline)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Management API");
});

app.UseHttpsRedirection();

app.UseAuthentication();

//middleware
app.UseCustomExceptionHandler();

app.UseCors(_policyName); //add core before authorization

app.UseAuthorization();

app.MapControllers();
#endregion

SeedData();

app.Run();

#region Helper Methods

async void SeedData()
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            var dbIdentityInitializer = services.GetRequiredService<IDbIdentityInitializer>();

            await dbIdentityInitializer.Initialize();

            Log.Information("Application Starting");
        }
        catch (Exception ex)
        {
            Log.Warning(ex, "An error occured while starting the application");
        }
    }
} 

#endregion