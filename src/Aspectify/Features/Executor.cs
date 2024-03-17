using Aspectify.Concerns;
using Microsoft.Extensions.DependencyInjection;

namespace Aspectify.Features;

public static class Executor
{
    internal static IServiceProvider? Container;

    public static async Task<TResult> Execute<TRequest, TResult>(this IFeature<TRequest, TResult> feature,
        TRequest request)
    {
        if ( Container is null )
            throw new InvalidOperationException("Features package is not initialized properly. IoC container is null.");

        var concerns = Container.GetServices<IConcern>().ToArray();

        var status = await Before(feature, request, concerns);

        if ( status.IsAborted ) return default;

        var result = await feature.Handle(request);

        await After(feature, request, result, concerns);

        return result;
    }

    private static async Task<ExecutionStatus> Before<TRequest, TResult>(IFeature<TRequest, TResult> feature,
        TRequest request, IEnumerable<IConcern> concerns)
    {
        foreach ( var concern in concerns )
        {
            var status = await concern.Before(feature, request);

            if ( status.IsAborted ) return status;
        }

        return ExecutionStatus.Continue;
    }

    private static Task After<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request, TResult result,
        IEnumerable<IConcern> concerns)
    {
        var tasks = concerns.Select(concern => concern.After(feature, request, result)).ToArray();

        return Task.WhenAll(tasks);
    }
}
