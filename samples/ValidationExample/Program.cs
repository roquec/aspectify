using Aspectify.Concerns;
using Aspectify.DependencyInjection;
using Aspectify.Logging.OpenTelemetry;
using Aspectify.Validation.FluentValidation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Util;
using ValidationExample;
using ValidationExample.CreateUser;

var host = SampleHost.BuildHost(
    services => services
        .AddTransient<Client>()
        .AddTransient<CreateUserFeature>()
        .AddTransient<IValidator<CreateUserRequest>, CreateUserRequestValidator>()
        .AddTransient(typeof(IConcern<,>), typeof(LoggingConcern<,>))
        .AddTransient(typeof(IConcern<,>), typeof(ValidationConcern<,>)),
    configure => configure
        .UseFeatures()
);

var client = host.Services.GetRequiredService<Client>();

await client.Run();
