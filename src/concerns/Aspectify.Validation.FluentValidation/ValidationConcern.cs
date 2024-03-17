using Aspectify.Concerns;
using Aspectify.Features;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aspectify.Validation.FluentValidation;

public class ValidationConcern<TRequest, TResult> : Concern<TRequest, TResult>
{
    private readonly IServiceProvider _container;

    public ValidationConcern(IServiceProvider container)
    {
        _container = container;
    }

    public override async Task Before(IFeature<TRequest, TResult> feature, TRequest request)
    {
        var validators = _container.GetServices<IValidator<TRequest>>().ToArray();

        foreach (var validator in validators)
        {
            var results = await validator.ValidateAsync(request);

            if(! results.IsValid)
            {
                foreach(var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }

                Context.IsExecutionAborted = true;
            }
        }
    }
}
