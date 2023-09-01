using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) //ICoreModule[] array yerine params ile ya da collection olarak da dönülebilir.
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
