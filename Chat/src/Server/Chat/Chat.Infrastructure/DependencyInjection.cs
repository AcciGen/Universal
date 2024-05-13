using Chat.Infrastructure.Repositories.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServer<ApplicationDbContext>(configuration.GetConnectionString("Default"));
            services.AddScoped<IMessageRepository, MessageRepository>();
            return services;
        }
    }
}
