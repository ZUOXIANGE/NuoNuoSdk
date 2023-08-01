namespace NuoNuoSdk.Responses;

/// <summary>
/// 发票作废响应
/// </summary>
public class InvoiceCancellationResponse : NuoNuoResponse<InvoiceCancellationDto>
{

}

public class InvoiceCancellationDto
{
    /// <summary>
    /// 发票流水号(提交成功则返回发票请求流水号)
    /// </summary>
    [JsonProperty("invoiceId")]
    [JsonPropertyName("invoiceId")]
    public string InvoiceId { get; set; }
}