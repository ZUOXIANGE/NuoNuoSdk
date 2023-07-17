global using System.Text;
global using System.Text.Json.Serialization;
global using Newtonsoft.Json;

using NuoNuoSdk.Dtos;
using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;

namespace NuoNuoSdk;

/// <summary>
/// 诺诺开放平台SDK
/// </summary>
public interface INuoNuoSdk
{
    /// <summary>
    /// 获取access_token
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<MerchantTokenResponse> GetMerchantTokenAsync(NuoNuoOptions options = null);

    /// <summary>
    /// ISV获取accessToken
    /// </summary>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<IsvTokenResponse> GetIsvTokenAsync(GetIsvTokenRequest request, NuoNuoOptions options = null);

    /// <summary>
    /// ISV刷新accessToken
    /// </summary>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    Task<IsvTokenResponse> RefreshIsvTokenAsync(RefreshIsvTokenRequest request, NuoNuoOptions options = null);

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="options"></param>
    /// <param name="canLog"></param>
    /// <returns></returns>
    Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, NuoNuoOptions options = null, bool canLog = true)
        where TRequest : NuoNuoRequest
        where TResponse : NuoNuoResponse;

}