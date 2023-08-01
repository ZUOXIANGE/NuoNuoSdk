namespace NuoNuoSdk.Requests;

/// <summary>
/// 获取isv token请求
/// </summary>
public class GetIsvTokenRequest
{
    /// <summary>
    /// 临时授权码，请求authorize时返回的code
    /// </summary>
    [JsonProperty("code")]
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 回调地址，此处配置的 redirect_uri 内容需要与应用中配置的授权回调地址完全一样
    /// </summary>
    [JsonProperty("redirect_uri")]
    [JsonPropertyName("redirect_uri")]
    public string RedirectUri { get; set; }

    /// <summary>
    /// 授权企业的税号，获取临时授权码返回的taxnum
    /// </summary>
    [JsonProperty("taxNum")]
    [JsonPropertyName("taxNum")]
    public string TaxNum { get; set; }
}