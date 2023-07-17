using NuoNuoSdk.Dtos;

namespace NuoNuoSdk.Requests;

/// <summary>
/// 请求开具发票接口(2.0)
/// </summary>
public class RequestBillingRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.requestBillingNew";

    /// <summary>
    /// Order
    /// </summary>
    [JsonPropertyName("order")]
    [JsonProperty("order")]
    public OrderDto Order { get; set; }
}