namespace NuoNuoSdk.Requests;

/// <summary>
/// 开票重试请求
/// </summary>
public class ReInvoiceRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.reInvoice";

    /// <summary>
    /// 流水号和订单号两字段二选，同时存在以流水号为准
    /// </summary>
    [JsonProperty("fpqqlsh")]
    [JsonPropertyName("fpqqlsh")]
    public string FlowNumber { get; set; }

    /// <summary>
    /// 订单号
    /// </summary>
    [JsonProperty("orderno")]
    [JsonPropertyName("orderno")]
    public string OrderNumber { get; set; }

    /// <summary>
    /// 指定发票代码（票种为c普纸、f收购纸票支持指定卷开票）
    /// </summary>
    [JsonProperty("nextInvoiceCode")]
    [JsonPropertyName("nextInvoiceCode")]
    public string InvoiceCode { get; set; }

    /// <summary>
    /// 发票起始号码，当指定代码有值时，发票起始号码必填
    /// </summary>
    [JsonProperty("invoiceNumStart")]
    [JsonPropertyName("invoiceNumStart")]
    public string InvoiceNumberStart { get; set; }

    /// <summary>
    /// 发票终止号码，当指定代码有值时，发票终止号码必填
    /// </summary>
    [JsonProperty("invoiceNumEnd")]
    [JsonPropertyName("invoiceNumEnd")]
    public string InvoiceNumberEnd { get; set; }
}