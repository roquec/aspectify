namespace Aspectify.Features;

public interface IFeature<in TRequest, TResult>
{
    public Task<TResult> Handle(TRequest request);
}