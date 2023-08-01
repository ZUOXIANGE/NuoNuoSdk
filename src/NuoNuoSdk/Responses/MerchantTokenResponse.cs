namespace NuoNuoSdk.Responses;

/// <summary>
/// 商户token响应
/// </summary>
public class MerchantTokenResponse
{
    /// <summary>
    /// 是否成功
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public bool Success => string.IsNullOrEmpty(ErrorCode);

    /// <summary>
    /// 接口请求唯一身份令牌
    /// </summary>
    [JsonProperty("access_token")]
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// access_token 的过期时长，24小时（单位秒
    /// </summary>
    [JsonProperty("expires_in")]
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// 错误
    /// </summary>
    [JsonProperty("error")]
    [JsonPropertyName("error")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// 错误描述
    /// </summary>
    [JsonProperty("error_description")]
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return $"access_token:{AccessToken} expires_in:{ExpiresIn}";
    }
}

