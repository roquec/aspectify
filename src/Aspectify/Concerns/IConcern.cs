using Aspectify.Features;

namespace Aspectify.Concerns;

public interface IConcern<TRequest, TResult>
{
    public void SetContext(ExecutionContext context);

    public Task Before(IFeature<TRequest, TResult> feature, TRequest request);

    public Task After(IFeature<TRequest, TResult> feature, TRequest request, TResult result);
}
