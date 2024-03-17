using Microsoft.Extensions.Logging;

using Aspectify.Concerns;
using Aspectify.Features;

namespace Aspectify.Logging.OpenTelemetry;

public class LoggingConcern<TRequest, TResult> : Concern<TRequest, TResult>
{
    private readonly ILoggerFactory _loggerFactory;

    public LoggingConcern(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public override Task Before(IFeature<TRequest, TResult> feature, TRequest request)
    {
        var logger = _loggerFactory.CreateLogger(feature.GetType());
        logger.LogInformation("Starting execution of feature [{feature}] with request [{request}]", feature, request);
        return Task.CompletedTask;
    }

    public override Task After(IFeature<TRequest, TResult> feature, TRequest request, TResult result)
    {
        var logger = _loggerFactory.CreateLogger(feature.GetType());
        logger.LogInformation("Finished execution of feature [{feature}] with request [{request}] ending with result [{result}]", feature, request, result);
        return Task.CompletedTask;
    }
}
