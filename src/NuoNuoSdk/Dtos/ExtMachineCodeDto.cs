namespace NuoNuoSdk.Dtos;

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