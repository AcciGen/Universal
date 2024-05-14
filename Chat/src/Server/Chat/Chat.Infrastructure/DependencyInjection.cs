using Chat.Infrastructure.Repositories.Chats;
using Chat.Infrastructure.Repositories.ChatUsers;
using Chat.Infrastructure.Repositories.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IChatUserRepository, ChatUserRepository>();

            return services;
        }
    }
}
