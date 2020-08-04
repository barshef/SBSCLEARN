using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SBSCLEARN.Service
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add MediatR Dependency Injection
        /// </summary>
        /// <param name="services"></param>
        public static void AddMediatorCQRS(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            // var assembly = AppDomain.CurrentDomain.Lsbsclearnd("SBSCLEARN.Service");
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}


