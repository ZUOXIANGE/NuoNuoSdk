namespace NuoNuoSdk.Responses;

public class GetInvoiceStockResponse : NuoNuoResponse<GetInvoiceStockDto>
{

}

public class GetInvoiceStockDto
{
    /// <summary>
    /// 分机号
    /// </summary>
    [JsonProperty("extensionNumber")]
    [JsonPropertyName("extensionNumber")]
    public int ExtensionNumber { get; set; }

    /// <summary>
    /// 机器编号
    /// </summary>
    [JsonProperty("machineCode")]
    [JsonPropertyName("machineCode")]
    public string MachineCode { get; set; }

    /// <summary>
    /// 终端号
    /// </summary>
    [JsonProperty("terminalNumber")]
    [JsonPropertyName("terminalNumber")]
    public string TerminalNumber { get; set; }

    /// <summary>
    /// 发票种类：p-电子增值税普通发票，c-增值税普通发票(纸票)，s-增值税专用发票，e-收购发票(电子)，
    /// f-收购发票(纸质)，r-增值税普通发票(卷式)，b-增值税电子专用发票，j-机动车销售统一发票，u-二手车销售统一发票
    /// </summary>
    [JsonProperty("invoiceLine")]
    [JsonPropertyName("invoiceLine")]
    public string InvoiceLine { get; set; }

    /// <summary>
    /// 剩余数量
    /// </summary>
    [JsonProperty("remainNum")]
    [JsonPropertyName("remainNum")]
    public int RemainNum { get; set; }

    /// <summary>
    /// 发票代码
    /// </summary>
    [JsonProperty("typeCode")]
    [JsonPropertyName("typeCode")]
    public string TypeCode { get; set; }

    /// <summary>
    /// 起始发票号码
    /// </summary>
    [JsonProperty("invoiceNumStart")]
    [JsonPropertyName("invoiceNumStart")]
    public string InvoiceNumStart { get; set; }

    /// <summary>
    /// 终止发票号码
    /// </summary>
    [JsonProperty("invoiceNumEnd")]
    [JsonPropertyName("invoiceNumEnd")]
    public string InvoiceNumEnd { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonProperty("updateTime")]
    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; }
}