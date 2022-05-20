using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicketManagement.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
