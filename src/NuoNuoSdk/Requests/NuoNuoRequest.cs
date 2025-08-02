namespace NuoNuoSdk.Requests;

/// <summary>
/// 诺诺请求基类
/// </summary>
public class NuoNuoRequest
{
    /// <summary>
    /// 请求api对应的方法名称【消息头】
    /// </summary>
    [JsonPropertyName("method")]
    public virtual string Method { get; set; }

    /// <summary>
    /// 授权码【消息头】
    /// </summary>
    [JsonIgnore]
    public string AccessToken { get; set; }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        Converters = { new DateTimeConverter(), new NullableDateTimeConverter() }
    };

    private Dictionary<string, string> _dic;

    /// <summary>
    /// 获取字典参数
    /// </summary>
    /// <returns></returns>
    public virtual Dictionary<string, string> GetDicParam()
    {
        if (_dic != null)
            return _dic;

        string json = JsonSerializer.Serialize(this, JsonOptions);
        _dic = JsonSerializer.Deserialize<Dictionary<string, string>>(json, JsonOptions);
        return _dic;
    }
}