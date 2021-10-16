using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using ComputerTechnicianBackend.API.Application.Validation.Abstractions;
using ComputerTechnicianBackend.Data.Services;

namespace ComputerTechnicianBackend.API.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLibraryServiceApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddComputerTechnicianServices();
            services.AddValidators();
        }

        private static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.Scan(
                    x => {
                        var entryAssembly = Assembly.GetEntryAssembly();
                        IEnumerable<Assembly> referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
                        IEnumerable<Assembly> assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);

                        x.FromAssemblies(assemblies)
                            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                            .AsImplementedInterfaces()
                            .WithScopedLifetime();
                    });
        }
    }
}
