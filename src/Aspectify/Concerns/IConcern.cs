using Aspectify.Features;

namespace Aspectify.Concerns;

public interface IConcern
{
    public Task<ExecutionStatus> Before<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request);

    public Task After<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request, TResult result);
}