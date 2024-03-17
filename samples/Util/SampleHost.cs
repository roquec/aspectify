using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Util;

public static class SampleHost
{
    public static IHost BuildHost(Action<IServiceCollection> services, Action<IServiceProvider> configure)
    {
        var builder = Host.CreateApplicationBuilder();

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        services(builder.Services);
        
        var host = builder.Build();

        configure(host.Services);

        return host;
    }
}