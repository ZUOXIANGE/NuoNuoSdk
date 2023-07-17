using Newtonsoft.Json.Serialization;

namespace NuoNuoSdk.Requests;

/// <summary>
/// 诺诺请求基类
/// </summary>
public class NuoNuoRequest
{
    /// <summary>
    /// 请求api对应的方法名称【消息头】
    /// </summary>
    [JsonProperty("method")]
    [JsonPropertyName("method")]
    public virtual string Method { get; set; }

    /// <summary>
    /// 授权码【消息头】
    /// </summary>
    [Newtonsoft.Json.JsonIgnore]
    [System.Text.Json.Serialization.JsonIgnore]
    public string AccessToken { get; set; }

    private static readonly JsonSerializerSettings JsonSetting = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore,
        DateFormatString = "yyyy-MM-dd HH:mm:ss"
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

        var json = JsonConvert.SerializeObject(this, JsonSetting);
        _dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        return _dic;
    }
}