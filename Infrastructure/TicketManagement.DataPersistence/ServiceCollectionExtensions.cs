global using TicketManagement.Application.Interfaces.Repositories;
global using TicketManagement.DataPersistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicketManagement.DataPersistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
             );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
