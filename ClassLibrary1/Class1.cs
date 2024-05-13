using Microsoft.Extensions.DependencyInjection;

namespace ClassLibrary1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
