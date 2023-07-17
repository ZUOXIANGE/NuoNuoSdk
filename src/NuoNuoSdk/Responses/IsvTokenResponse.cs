namespace NuoNuoSdk.Responses;

public class IsvTokenResponse
{
    /// <summary>
    /// 访问令牌
    /// </summary>
    [JsonProperty("access_token")]
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// access_token 的过期时长，24小时（单位秒）
    /// </summary>
    [JsonProperty("expires_in")]
    [JsonPropertyName("expires_in")]
    public string ExpiresIn { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    [JsonProperty("refresh_token")]
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// 授权者的用户ID(如果需要刷新令牌开发者应妥善保存)
    /// </summary>
    [JsonProperty("userId")]
    [JsonPropertyName("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// 授权商户相应信息
    /// </summary>
    [JsonProperty("oauthUser")]
    [JsonPropertyName("oauthUser")]
    public string OauthUser { get; set; }

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
}