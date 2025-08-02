namespace NuoNuoSdk.Requests;

/// <summary>
/// 刷新isv token请求
/// </summary>
public class RefreshIsvTokenRequest
{
    /// <summary>
    /// 刷新令牌
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// 获取access_token时授权商户的userId
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}