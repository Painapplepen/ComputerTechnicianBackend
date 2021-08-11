using Microsoft.Extensions.DependencyInjection;

namespace ComputerTechnicianBackend.Data.EF.SQL
{
    public static  class ServiceCollectionExtensions
    {
        public static void AddComputerTechnicianDbContext(this IServiceCollection services)
        {
            services.AddScoped<ComputerTechnicianDbContext>();
        }
    }
}
