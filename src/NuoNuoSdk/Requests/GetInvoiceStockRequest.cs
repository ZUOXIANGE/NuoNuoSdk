namespace NuoNuoSdk.Requests;

/// <summary>
/// 企业发票余量查询接口请求
/// </summary>
public class GetInvoiceStockRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.getInvoiceStock";

    /// <summary>
    /// 部门id（不传分机号、机器编号时使用）；部门和分机、机器编号等都不传时，返回税号下全部报税信息
    /// </summary>
    [JsonProperty("departmentId")]
    [JsonPropertyName("departmentId")]
    public string DepartmentId { get; set; }

    /// <summary>
    /// 分机号列表（只传分机号时使用）
    /// </summary>
    [JsonProperty("extensionNums")]
    [JsonPropertyName("extensionNums")]
    public List<string> ExtensionNums { get; set; }

    /// <summary>
    /// 机器编号单个查询（只传机器编号时使用）
    /// </summary>
    [JsonProperty("machineCode")]
    [JsonPropertyName("machineCode")]
    public string MachineCode { get; set; }

    /// <summary>
    /// 分机号+机器编号联合查询（只能传入一对分机号和机器编号），精确查询某设备时建议使用此种方式
    /// </summary>
    [JsonProperty("extMachineCodePairs")]
    [JsonPropertyName("extMachineCodePairs")]
    public List<ExtMachineCodeDto> ExtMachineCodePairs { get; set; }
}

public class ExtMachineCodeDto
{
    /// <summary>
    /// 分机号
    /// </summary>
    [JsonProperty("extNum")]
    [JsonPropertyName("extNum")]
    public string ExtensionNum { get; set; }

    /// <summary>
    /// 机器编号
    /// </summary>
    [JsonProperty("machineCode")]
    [JsonPropertyName("machineCode")]
    public string MachineCode { get; set; }
}