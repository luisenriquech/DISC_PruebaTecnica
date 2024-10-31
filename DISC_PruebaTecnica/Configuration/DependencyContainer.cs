using MediatR;

namespace DISC_PruebaTecnica.Configuration
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(IInPutPort<,>).Assembly);

            return services;
        }
    }
}
