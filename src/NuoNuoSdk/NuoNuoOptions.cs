namespace NuoNuoSdk;

public class NuoNuoOptions
{
    /// <summary>
    /// SDK请求地址
    /// </summary>
    public string SdkRequestUrl { get; set; } = "https://sdk.nuonuo.com/open/v1/services";

    /// <summary>
    /// token请求地址
    /// </summary>
    public string TokenRequestUrl { get; set; } = "https://open.nuonuo.com/accessToken";

    /// <summary>
    /// 平台分配给应用的appKey
    /// </summary>
    public string AppKey { get; set; }

    /// <summary>
    /// 平台分配给应用的appSecret
    /// </summary>
    public string AppSecret { get; set; }

    /// <summary>
    /// 授权商户的税号（自用型应用非必填，第三方应用必填）【消息头】
    /// </summary>
    public string UserTax { get; set; }

    /// <summary>
    /// 超时时间
    /// </summary>
    public int Timeout { get; set; } = 3;

    /// <summary>
    /// Sdk版本(默认值和Java SDK版本一样)
    /// </summary>
    public string Version { get; set; } = "1.0.5.2";

}