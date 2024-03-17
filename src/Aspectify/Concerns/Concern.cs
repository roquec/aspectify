using Aspectify.Features;

namespace Aspectify.Concerns;

public abstract class Concern<TRequest, TResult> : IConcern<TRequest, TResult>
{
    public ExecutionContext Context { get; private set; } = new ();

    public void SetContext(ExecutionContext context)
    {
        Context = context;
    }

    public virtual Task Before(IFeature<TRequest, TResult> feature, TRequest request)
    {
        return Task.CompletedTask;
    }

    public virtual Task After(IFeature<TRequest, TResult> feature, TRequest request, TResult result)
    {
        return Task.CompletedTask;
    }
}
