using Aspectify.Concerns;
using Aspectify.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Aspectify;

public static class Executor
{
    internal static IServiceProvider? Container;

    public static async Task<TResult> Execute<TRequest, TResult>(Func<TRequest, Task<TResult>> function, TRequest request)
    {
        var feature = new DefaultFeature<TRequest, TResult>(function);
        return await Execute(feature, request);
    }

    public static async Task<TResult> Execute<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request)
    {
        if (Container is null)
        {
            throw new InvalidOperationException("Features package is not initialized properly. IoC container is null.");
        }

        var context = new ExecutionContext();

        IConcern<TRequest, TResult>[] concerns = Container.GetServices<IConcern<TRequest, TResult>>().ToArray();

        foreach (IConcern<TRequest,TResult> concern in concerns)
        {
            concern.SetContext(context);
        }

        await Before(feature, request, concerns);

        if (context.IsExecutionAborted)
        {
            throw new Exception("Execution aborted!");
        }

        TResult result = await feature.Handle(request);

        await After(feature, request, result, concerns);

        return result;
    }

    private static async Task Before<TRequest, TResult>(
        IFeature<TRequest, TResult> feature,
        TRequest request,
        IEnumerable<IConcern<TRequest, TResult>> concerns)
    {
        foreach (IConcern<TRequest, TResult> concern in concerns)
        {
            await concern.Before(feature, request);
        }
    }

    private static async Task After<TRequest, TResult>(
        IFeature<TRequest, TResult> feature,
        TRequest request, TResult result,
        IEnumerable<IConcern<TRequest, TResult>> concerns)
    {
        foreach (IConcern<TRequest, TResult> concern in concerns.Reverse())
        {
            await concern.After(feature, request, result);
        }
    }
}
