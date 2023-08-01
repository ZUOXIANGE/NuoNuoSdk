namespace NuoNuoSdk.Responses;

/// <summary>
/// 请求开具发票响应
/// </summary>
public class RequestBillingResponse : NuoNuoResponse<RequestBillingDto>
{

}

public class RequestBillingDto
{
    /// <summary>
    /// 发票流水号
    /// </summary>
    [JsonProperty("invoiceSerialNum")]
    public string InvoiceSerialNum { get; set; }
}