using Chat.Application.Services.Chats;
using Chat.Application.Services.ChatUsers;
using Chat.Application.Services.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IChatUsersService, ChatUsersService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
