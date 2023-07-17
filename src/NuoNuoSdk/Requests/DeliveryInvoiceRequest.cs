namespace NuoNuoSdk.Requests;

/// <summary>
/// 发票重新交付请求
/// </summary>
public class DeliveryInvoiceRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.deliveryInvoice";

    /// <summary>
    /// 销方税号
    /// </summary>
    [JsonProperty("taxnum")]
    [JsonPropertyName("taxnum")]
    public string TaxNumber { get; set; }

    /// <summary>
    /// 发票代码（全电发票时可为空）
    /// </summary>
    [JsonProperty("invoiceCode")]
    [JsonPropertyName("invoiceCode")]
    public string InvoiceCode { get; set; }

    /// <summary>
    /// 发票号码（全电发票时为20位，其他发票时为8位）
    /// </summary>
    [JsonProperty("invoiceNum")]
    [JsonPropertyName("invoiceNum")]
    public string InvoiceNumber { get; set; }

    /// <summary>
    /// 交付手机号，和交付邮箱至少有一个不为空
    /// </summary>
    [JsonProperty("phone")]
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// 交付邮箱，和交付手机号至少有一个不为空
    /// </summary>
    [JsonProperty("mail")]
    [JsonPropertyName("mail")]
    public string Mail { get; set; }
}