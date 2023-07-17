namespace NuoNuoSdk.Responses;

/// <summary>
/// 诺诺响应基类
/// </summary>
public class NuoNuoResponse
{
    /// <summary>
    /// 是否成功
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public bool Success => "E0000" == Code;

    /// <summary>
    /// 原始响应body
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public string Body { get; set; }

    /// <summary>
    /// 异常码
    /// </summary>
    [JsonProperty("code")]
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 异常描述
    /// </summary>
    [JsonProperty("describe")]
    [JsonPropertyName("describe")]
    public string Describe { get; set; }

}

public class NuoNuoResponse<T> : NuoNuoResponse
{
    /// <summary>
    /// 结果
    /// </summary>
    [JsonProperty("result")]
    [JsonPropertyName("result")]
    public T Result { get; set; }
}