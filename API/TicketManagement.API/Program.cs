#region Using Statements
global using TicketManagement.Application;
global using TicketManagement.DataPersistence;
global using TicketManagement.Infrastructure;
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSwaggerGen(); 

#endregion

var app = builder.Build();

#region Configure: Configure the HTTP request pipeline (Middleware pipline)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(_policyName); //add core before authorization

app.UseAuthorization();

app.MapControllers(); 
#endregion

app.Run();
