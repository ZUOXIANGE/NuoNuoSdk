namespace NuoNuoSdk.Requests;

/// <summary>
/// 发票作废请求
/// </summary>
public class InvoiceCancellationRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.electronInvoice.invoiceCancellation";

    /// <summary>
    /// 发票流水号
    /// </summary>
    [JsonProperty("invoiceId")]
    [JsonPropertyName("invoiceId")]
    public string InvoiceId { get; set; }

    /// <summary>
    /// 发票代码
    /// </summary>
    [JsonProperty("invoiceCode")]
    [JsonPropertyName("invoiceCode")]
    public string InvoiceCode { get; set; }

    /// <summary>
    /// 发票号码
    /// </summary>
    [JsonProperty("invoiceNo")]
    [JsonPropertyName("invoiceNo")]
    public string InvoiceNo { get; set; }
}