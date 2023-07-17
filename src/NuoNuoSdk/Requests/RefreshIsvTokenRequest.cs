namespace NuoNuoSdk.Requests;

public class RefreshIsvTokenRequest
{
    /// <summary>
    /// 刷新令牌
    /// </summary>
    [JsonProperty("refresh_token")]
    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// 获取access_token时授权商户的userId
    /// </summary>
    [JsonProperty("userId")]
    [JsonPropertyName("userId")]
    public string UserId { get; set; }
}