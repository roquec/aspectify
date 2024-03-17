using Aspectify.Features;

namespace Aspectify.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceProvider UseFeatures(this IServiceProvider services)
    {
        Executor.Container = services;
        return services;
    }   
}