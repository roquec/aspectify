namespace Aspectify.Features;

public class DefaultFeature<TRequest, TResult> : IFeature<TRequest, TResult>
{
    private readonly Func<TRequest, Task<TResult>> _function;

    public DefaultFeature(Func<TRequest, Task<TResult>> function)
    {
        _function = function;
    }

    public async Task<TResult> Handle(TRequest request)
    {
        return await _function(request);
    }
}
