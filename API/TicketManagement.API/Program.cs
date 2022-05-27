#region Using Statements
global using TicketManagement.Application;
global using TicketManagement.DataPersistence;
global using TicketManagement.Infrastructure;
using Microsoft.OpenApi.Models;
using TicketManagement.API.Middleware;
#endregion

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices : Add services to the container.

#region  Add Application, DataPersistence and Infrastructure Libraries
builder.Services.AddDataPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
#endregion

builder.Services.AddControllers();

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

});

    //support csv files
    //c.OperationFilter<FileResultContentTypeOperationFilter>();
}); 
#endregion

#endregion

var app = builder.Build();

#region Configure: Configure the HTTP request pipeline (Middleware pipline)
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Management API");
    });
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.UseCors(_policyName); //add core before authorization

app.UseAuthorization();

app.MapControllers(); 
#endregion

app.Run();
