namespace NuoNuoSdk.Responses;

/// <summary>
/// 企业发票余量查询响应
/// </summary>
public class GetInvoiceStockResponse : NuoNuoResponse<GetInvoiceStockDto>
{

}

public class GetInvoiceStockDto
{
    /// <summary>
    /// 分机号
    /// </summary>
    [JsonPropertyName("extensionNumber")]
    public int ExtensionNumber { get; set; }

    /// <summary>
    /// 机器编号
    /// </summary>
    [JsonPropertyName("machineCode")]
    public string MachineCode { get; set; }

    /// <summary>
    /// 终端号
    /// </summary>
    [JsonPropertyName("terminalNumber")]
    public string TerminalNumber { get; set; }

    /// <summary>
    /// 发票种类：p-电子增值税普通发票，c-增值税普通发票(纸票)，s-增值税专用发票，e-收购发票(电子)，
    /// f-收购发票(纸质)，r-增值税普通发票(卷式)，b-增值税电子专用发票，j-机动车销售统一发票，u-二手车销售统一发票
    /// </summary>
    [JsonPropertyName("invoiceLine")]
    public string InvoiceLine { get; set; }

    /// <summary>
    /// 剩余数量
    /// </summary>
    [JsonPropertyName("remainNum")]
    public int RemainNum { get; set; }

    /// <summary>
    /// 发票代码
    /// </summary>
    [JsonPropertyName("typeCode")]
    public string TypeCode { get; set; }

    /// <summary>
    /// 起始发票号码
    /// </summary>
    [JsonPropertyName("invoiceNumStart")]
    public string InvoiceNumStart { get; set; }

    /// <summary>
    /// 终止发票号码
    /// </summary>
    [JsonPropertyName("invoiceNumEnd")]
    public string InvoiceNumEnd { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; }
}