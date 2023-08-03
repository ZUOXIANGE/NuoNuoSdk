using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        var timeout = config.GetValue<int>("Timeout");
        if (timeout < 3)
            timeout = 3;

        serviceBuilder.AddHttpClient(nameof(NuoNuoSdk), client =>
        {
            client.Timeout = TimeSpan.FromSeconds(timeout);
        });
        return serviceBuilder;
    }
}