namespace NuoNuoSdk.Requests;

/// <summary>
/// 开票结果查询请求
/// </summary>
public class QueryInvoiceResultRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.queryInvoiceResult";

    /// <summary>
    /// 发票流水号，两字段二选一，同时存在以流水号为准（最多查50个订单号）
    /// </summary>
    [JsonProperty("serialNos")]
    [JsonPropertyName("serialNos")]
    public List<string> SerialNos { get; set; }

    /// <summary>
    /// 订单编号（最多查50个订单号）
    /// </summary>
    [JsonProperty("orderNos")]
    [JsonPropertyName("orderNos")]
    public List<string> OrderNos { get; set; }

    /// <summary>
    /// 是否需要提供明细 1-是, 0-否(不填默认 0)
    /// </summary>
    [JsonProperty("isOfferInvoiceDetail")]
    [JsonPropertyName("isOfferInvoiceDetail")]
    public string IsOfferInvoiceDetail { get; set; }
}