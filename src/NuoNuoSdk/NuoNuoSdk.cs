using System.Security.Cryptography;
using System.Web;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;

namespace NuoNuoSdk;

/// <summary>
/// 诺诺开放平台SDK
/// </summary>
public class NuoNuoSdk : INuoNuoSdk
{
    private static readonly JsonSerializerSettings JsonSetting = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore,
        DateFormatString = "yyyy-MM-dd HH:mm:ss"
    };

    private readonly IHttpClientFactory _clientFactory;
    private readonly ILogger<NuoNuoSdk> _logger;
    private readonly NuoNuoOptions _options;

    public NuoNuoSdk(IHttpClientFactory clientFactory, ILogger<NuoNuoSdk> logger, IOptions<NuoNuoOptions> options)
    {
        _clientFactory = clientFactory;
        _logger = logger;
        _options = options.Value;
    }

    /// <summary>
    /// 获取access_token
    /// </summary>
    /// <param name="options">指定配置</param>
    /// <returns><see cref="MerchantTokenResponse"/></returns>
    public async Task<MerchantTokenResponse> GetMerchantTokenAsync(NuoNuoOptions options = null)
    {
        options ??= _options;
        var dic = new Dictionary<string, string>
        {
            { "client_id", options.AppKey },
            { "client_secret", options.AppSecret },
            { "grant_type", "client_credentials" }
        };
        var data = await PostFormAsync(dic, options);
        return JsonConvert.DeserializeObject<MerchantTokenResponse>(data);
    }

    /// <summary>
    /// ISV获取accessToken
    /// </summary>
    /// <param name="request"><see cref="GetIsvTokenRequest"/></param>
    /// <param name="options">指定配置</param>
    /// <returns><see cref="IsvTokenResponse"/></returns>
    public async Task<IsvTokenResponse> GetIsvTokenAsync(GetIsvTokenRequest request, NuoNuoOptions options = null)
    {
        options ??= _options;
        var dic = new Dictionary<string, string>
        {
            { "client_id", options.AppKey },
            { "client_secret", options.AppSecret },
            { "redirect_uri", request.RedirectUri },
            { "code", request.Code },
            { "taxNum", options.UserTax },
            { "grant_type", "authorization_code" }
        };
        var data = await PostFormAsync(dic, options);
        return JsonConvert.DeserializeObject<IsvTokenResponse>(data);
    }

    /// <summary>
    /// ISV刷新accessToken
    /// </summary>
    /// <param name="request"><see cref="RefreshIsvTokenRequest"/></param>
    /// <param name="options">指定配置</param>
    /// <returns><see cref="IsvTokenResponse"/></returns>
    public async Task<IsvTokenResponse> RefreshIsvTokenAsync(RefreshIsvTokenRequest request, NuoNuoOptions options = null)
    {
        options ??= _options;
        var dic = new Dictionary<string, string>
        {
            { "refresh_token", request.RefreshToken },
            { "client_id", request.UserId },
            { "client_secret", options.AppSecret },
            { "grant_type", "refresh_token" }
        };
        var data = await PostFormAsync(dic, options);
        return JsonConvert.DeserializeObject<IsvTokenResponse>(data);
    }

    /// <summary>
    /// 执行请求
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="options">指定配置</param>
    /// <param name="enableLog">是否开启日志记录</param>
    /// <returns></returns>
    public async Task<TResponse> ExecuteAsync<TRequest, TResponse>(TRequest request, NuoNuoOptions options = null, bool enableLog = true)
        where TRequest : NuoNuoRequest
        where TResponse : NuoNuoResponse
    {
        options ??= _options;
        if (string.IsNullOrEmpty(request.AccessToken))
            request.AccessToken = options.AccessToken;
        if (string.IsNullOrEmpty(request.AccessToken))
            throw new ArgumentNullException(nameof(request.AccessToken));

        //参数生成
        var nonce = new Random().Next(10000000, 99999999).ToString();
        var senId = Guid.NewGuid().ToString("N");
        var timestamp = GetTimestamp();
        var body = JsonConvert.SerializeObject(request, JsonSetting);

        //url拼接
        var url = new StringBuilder(options.SdkRequestUrl);
        url.Append("?senid=").Append(senId)
            .Append("&nonce=").Append(nonce)
            .Append("&timestamp=").Append(timestamp)
            .Append("&appkey=").Append(options.AppKey);
        var requestUri = new Uri(url.ToString());

        //签名
        var sign = GetSign(requestUri, body, options);

        //header设置
        var client = _clientFactory.CreateClient(nameof(NuoNuoSdk));
        var header = new Dictionary<string, string>
        {
            { "X-Nuonuo-Sign", sign },
            { "accessToken", request.AccessToken },
            { "userTax", options.UserTax },
            { "method", request.Method },
            { "sdkVer",options.Version }
        };
        foreach (var h in header)
        {
            client.DefaultRequestHeaders.Add(h.Key, h.Value);
        }

        HttpContent httpContent = new StringContent(body, Encoding.UTF8, "application/json");
        if (enableLog)
            _logger.LogInformation("诺诺请求:header: {@header} body: {body}", header, body);

        var res = await client.PostAsync(requestUri, httpContent);
        var data = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"诺诺请求异常:{data}");
        }
        if (enableLog)
            _logger.LogInformation("诺诺返回:{data}", data);

        var response = JsonConvert.DeserializeObject<TResponse>(data);
        response.Body = data;
        return response;
    }


    #region private method

    /// <summary>
    /// 执行form请求
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    private async Task<string> PostFormAsync(Dictionary<string, string> dic, NuoNuoOptions options)
    {
        var client = _clientFactory.CreateClient(nameof(NuoNuoSdk));
        var req = new HttpRequestMessage(HttpMethod.Post, options.TokenRequestUrl)
        {
            Content = new FormUrlEncodedContent(dic)
        };
        _logger.LogInformation("诺诺请求:{@dic}", dic);
        var res = await client.SendAsync(req);
        var data = await res.Content.ReadAsStringAsync();
        _logger.LogInformation("诺诺返回:{@data}", data);
        return data;
    }

    private static readonly DateTime Time1970 = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <returns></returns>
    private static string GetTimestamp()
    {
        var ts = DateTime.UtcNow - Time1970;
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }

    /// <summary>
    /// 获取签名
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="body"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    private static string GetSign(Uri requestUri, string body, NuoNuoOptions options)
    {
        var split = requestUri.AbsolutePath.Split('/');
        if (split.Length < 4) throw new ArgumentException("path不正确");

        var query = HttpUtility.ParseQueryString(requestUri.Query);
        var signStr = new StringBuilder();
        signStr.Append("a=" + split[3])
            .Append("&l=" + split[2])
            .Append("&p=" + split[1])
            .Append("&k=" + options.AppKey)
            .Append("&i=" + query["senId"])
            .Append("&n=" + query["nonce"])
            .Append("&t=" + query["timestamp"])
            .Append("&f=" + body);
        return HmacSha1WithBase64(signStr.ToString(), options.AppSecret);
    }

    /// <summary>
    /// 计算签名
    /// </summary>
    /// <param name="value"></param>
    /// <param name="secret"></param>
    /// <returns></returns>
    private static string HmacSha1WithBase64(string value, string secret)
    {
        var encoding = Encoding.UTF8;
        var keyBytes = encoding.GetBytes(secret);
        var hmacSha1 = new HMACSHA1(keyBytes);
        var messageBytes = encoding.GetBytes(value);
        var rawHmac = hmacSha1.ComputeHash(messageBytes);
        var res = Convert.ToBase64String(rawHmac);
        return res;
    }

    #endregion

}