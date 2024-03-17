using Aspectify.Concerns;
using Aspectify.DependencyInjection;
using Aspectify.Logging.OpenTelemetry;
using HelloWorld;
using HelloWorld.GetGreetingByName;
using Microsoft.Extensions.DependencyInjection;
using Util;

var host = SampleHost.BuildHost(
    services => services
        .AddTransient<Client>()
        .AddTransient<GetGreetingByNameFeature>()
        .AddTransient<IConcern, LoggingConcern>(),
    configure => configure
        .UseFeatures()
);

var client = host.Services.GetRequiredService<Client>();

await client.Run();