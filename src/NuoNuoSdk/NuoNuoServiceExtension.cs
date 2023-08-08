using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace NuoNuoSdk;

public static class NuoNuoServiceExtension
{
    /// <summary>
    /// 添加诺诺开放平台SDK
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <param name="configuration"></param>
    /// <param name="configName"></param>
    /// <returns></returns>
    public static IServiceCollection AddNuoNuoSdk(this IServiceCollection serviceBuilder,
        IConfiguration configuration, string configName = "NuoNuoOptions")
    {
        var config = configuration.GetSection(configName);
        serviceBuilder.Configure<NuoNuoOptions>(config);
        serviceBuilder.TryAddSingleton<INuoNuoSdk, NuoNuoSdk>();

        serviceBuilder.AddHttpClient(nameof(NuoNuoSdk), (serviceProvider, client) =>
        {
            var options = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
            var timeout = options.Value.Timeout;
            if (timeout < 3)
                timeout = 3;
            client.Timeout = TimeSpan.FromSeconds(timeout);
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.All
        });
        return serviceBuilder;
    }

    /// <summary>
    /// 添加诺诺开放平台SDK
    /// </summary>
    /// <param name="serviceBuilder"></param>
    /// <param name="configureOptions"></param>
    /// <returns></returns>
    public static IServiceCollection AddNuoNuoSdk(this IServiceCollection serviceBuilder,
        Action<NuoNuoOptions> configureOptions)
    {
        serviceBuilder.Configure(configureOptions);
        serviceBuilder.TryAddSingleton<INuoNuoSdk, NuoNuoSdk>();

        serviceBuilder.AddHttpClient(nameof(NuoNuoSdk), (serviceProvider, client) =>
        {
            var options = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
            var timeout = options.Value.Timeout;
            if (timeout < 3)
                timeout = 3;
            client.Timeout = TimeSpan.FromSeconds(timeout);
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        }).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.All
        });
        return serviceBuilder;
    }
}