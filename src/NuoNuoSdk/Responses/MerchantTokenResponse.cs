namespace NuoNuoSdk.Responses;

/// <summary>
/// 商户token响应
/// </summary>
public class MerchantTokenResponse
{
    /// <summary>
    /// 是否成功
    /// </summary>
    [JsonIgnore]
    public bool Success => string.IsNullOrEmpty(ErrorCode);

    /// <summary>
    /// 接口请求唯一身份令牌
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// access_token 的过期时长，24小时（单位秒
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// 错误
    /// </summary>
    [JsonPropertyName("error")]
    public string ErrorCode { get; set; }

    /// <summary>
    /// 错误描述
    /// </summary>
    [JsonPropertyName("error_description")]
    public string ErrorDescription { get; set; }

    public override string ToString()
    {
        return $"access_token:{AccessToken} expires_in:{ExpiresIn}";
    }
}

