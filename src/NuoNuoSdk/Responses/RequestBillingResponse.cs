namespace NuoNuoSdk.Responses;

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