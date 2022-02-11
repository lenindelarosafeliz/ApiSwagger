using Applications.Interfaces;
using Infrastructure.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Shared
{
    public static class IoCRegister
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddRegisterRepository();

        }

        public static IServiceCollection AddRegisterRepository(this IServiceCollection services)
        {

            return services.AddTransient<IPersonaRepository, PersonaRepository>()
                           .AddTransient<IUnitOfWork, UnitOfWork>();
        }

    }
}