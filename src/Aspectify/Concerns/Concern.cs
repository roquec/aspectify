using Aspectify.Features;

namespace Aspectify.Concerns;

public abstract class Concern : IConcern
{
    public virtual Task<ExecutionStatus> Before<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request)
    {
        return Task.FromResult(ExecutionStatus.Continue);
    }

    public virtual Task After<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request, TResult result)
    {
        return Task.CompletedTask;
    }
}