namespace Aspectify.Features;

public static class FeatureExtensions
{
    public static async Task<TResult> Execute<TRequest, TResult>(
        this IFeature<TRequest, TResult> feature,
        TRequest request)
    {
        return await Executor.Execute(feature, request);
    }
}
