using Aspectify.Concerns;
using Aspectify.Features;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Aspectify.Validation.FluentValidation;

public class ValidationConcern : Concern
{
    private readonly IServiceProvider _container;

    public ValidationConcern(IServiceProvider container)
    {
        _container = container;
    }
    
    public override async Task<ExecutionStatus> Before<TRequest, TResult>(IFeature<TRequest, TResult> feature, TRequest request)
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

                return ExecutionStatus.Abort;
            }
        }

        return ExecutionStatus.Continue;
    }
}