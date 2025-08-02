namespace NuoNuoSdk.Responses;

/// <summary>
/// 诺诺响应基类
/// </summary>
public class NuoNuoResponse
{
    /// <summary>
    /// 是否成功
    /// </summary>
    [JsonIgnore]
    public bool Success => Code == "E0000";

    /// <summary>
    /// 原始响应body
    /// </summary>
    [JsonIgnore]
    public string Body { get; set; }

    /// <summary>
    /// 异常码
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// 异常描述
    /// </summary>
    [JsonPropertyName("describe")]
    public string Describe { get; set; }

}

/// <summary>
/// 诺诺响应基类(泛型)
/// </summary>
/// <typeparam name="T"></typeparam>
public class NuoNuoResponse<T> : NuoNuoResponse
{
    /// <summary>
    /// 结果
    /// </summary>
    [JsonPropertyName("result")]
    public T Result { get; set; }
}