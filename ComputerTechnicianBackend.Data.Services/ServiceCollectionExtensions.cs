using ComputerTechnicianBackend.Data.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using ComputerTechnicianBackend.Data.EF.SQL;

namespace ComputerTechnicianBackend.Data.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddComputerTechnicianServices(this IServiceCollection services)
        {
            services.AddComputerTechnicianDbContext();
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            var currentAssembly = typeof(ServiceCollectionExtensions);

            services.Scan(scan => scan.FromAssembliesOf(currentAssembly)
                .AddClasses(classes => classes.AssignableTo(typeof(IBaseService<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );

        }
    }
}
