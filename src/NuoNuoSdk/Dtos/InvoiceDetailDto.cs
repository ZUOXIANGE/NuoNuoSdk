namespace NuoNuoSdk.Dtos;

/// <summary>
/// 发票明细
/// </summary>
public class InvoiceDetailDto
{
    /// <summary>
    /// 商品名称（如invoiceLineProperty =1，则此商品行为折扣行，折扣行不允许多行折扣，折扣行必须紧邻被折扣行，商品名称必须与被折扣行一致）
    /// </summary>
    [JsonPropertyName("goodsName")]
    [JsonProperty("goodsName")]
    public string GoodsName { get; set; }

    /// <summary>
    /// 商品编码（商品税收分类编码开发者自行填写）
    /// </summary>
    [JsonPropertyName("goodsCode")]
    [JsonProperty("goodsCode")]
    public string GoodsCode { get; set; }

    /// <summary>
    /// 自行编码（可不填）
    /// </summary>
    [JsonPropertyName("selfCode")]
    [JsonProperty("selfCode")]
    public string SelfCode { get; set; }

    /// <summary>
    /// 单价含税标志：0:不含税,1:含税
    /// </summary>
    [JsonPropertyName("withTaxFlag")]
    [JsonProperty("withTaxFlag")]
    public string WithTaxFlag { get; set; }

    /// <summary>
    /// 单价（精确到小数点后8位），当单价(price)为空时，数量(num)也必须为空；
    /// (price) 为空时，含税金额(taxIncludedAmount)、不含税金额(taxExcludedAmount)、税额(tax)都不能为空
    /// </summary>
    [JsonPropertyName("price")]
    [JsonProperty("price")]
    public string Price { get; set; }

    /// <summary>
    /// 数量（精确到小数点后8位，开具红票时数量为负数）
    /// </summary>
    [JsonPropertyName("num")]
    [JsonProperty("num")]
    public string Num { get; set; }

    /// <summary>
    /// 单位
    /// </summary>
    [JsonPropertyName("unit")]
    [JsonProperty("unit")]
    public string Unit { get; set; }

    /// <summary>
    /// 规格型号
    /// </summary>
    [JsonPropertyName("specType")]
    [JsonProperty("specType")]
    public string SpecType { get; set; }

    /// <summary>
    /// 税额，[不含税金额] * [税率] = [税额]；税额允许误差为 0.06。
    /// 红票为负。不含税金额、税额、含税金额任何一个不传时，会根据传入的单价，数量进行计算，可能和实际数值存在误差，建议都传入
    /// </summary>
    [JsonPropertyName("tax")]
    [JsonProperty("tax")]
    public string Tax { get; set; }

    /// <summary>
    /// 税率，注：1、纸票清单红票存在为null的情况；2、二手车发票税率为null或者0
    /// </summary>
    [JsonPropertyName("taxRate")]
    [JsonProperty("taxRate")]
    public string TaxRate { get; set; }

    /// <summary>
    /// 不含税金额。红票为负。
    /// 不含税金额、税额、含税金额任何一个不传时，会根据传入的单价，数量进行计算，可能和实际数值存在误差，建议都传入
    /// </summary>
    [JsonPropertyName("taxExcludedAmount")]
    [JsonProperty("taxExcludedAmount")]
    public string TaxExcludedAmount { get; set; }

    /// <summary>
    /// 含税金额，[不含税金额] + [税额] = [含税金额]，红票为负。
    /// 不含税金额、税额、含税金额任何一个不传时，会根据传入的单价，数量进行计算，可能和实际数值存在误差，建议都传入
    /// </summary>
    [JsonPropertyName("taxIncludedAmount")]
    public string TaxIncludedAmount { get; set; }

    /// <summary>
    /// 发票行性质：0,正常行;1,折扣行;2,被折扣行，红票只有正常行
    /// </summary>
    [JsonPropertyName("invoiceLineProperty")]
    [JsonProperty("invoiceLineProperty")]
    public string InvoiceLineProperty { get; set; }

    /// <summary>
    /// 优惠政策标识：0,不使用;1,使用;
    /// 全电发票时： 01：简易征收 02：稀土产品 03：免税 04：不征税 05：先征后退
    /// 06：100%先征后退 07：50%先征后退 08：按3%简易征收 09：按5%简易征收 10按5%简易征收减按1.5%计征
    /// 11：即征即退30%12：即征即退50% 13：即征即退70% 14：即征即退100% 15：超税负3%即征即退
    /// 16：超税负8%即征即退 17：超税负12%即征即退 18：超税负6%即征即退
    /// </summary>
    [JsonPropertyName("favouredPolicyFlag")]
    [JsonProperty("favouredPolicyFlag")]
    public string FavouredPolicyFlag { get; set; }

    /// <summary>
    /// 增值税特殊管理（优惠政策名称）,当favouredPolicyFlag为1时，此项必填 （全电发票时为空）
    /// </summary>
    [JsonPropertyName("favouredPolicyName")]
    [JsonProperty("favouredPolicyName")]
    public string FavouredPolicyName { get; set; }

    /// <summary>
    /// 扣除额，差额征收时填写，目前只支持填写一项。
    /// 注意：当传0、空或字段不传时，都表示非差额征税；
    /// 传0.00才表示差额征税：0.00 （全电发票暂不支持）
    /// </summary>
    [JsonPropertyName("deduction")]
    [JsonProperty("deduction")]
    public string Deduction { get; set; }

    /// <summary>
    /// 零税率标识：空,非零税率;1,免税;2,不征税;3,普通零税率；
    /// 1、当税率为：0%，且增值税特殊管理：为“免税”， 零税率标识：需传“1”
    /// 2、当税率为：0%，且增值税特殊管理：为"不征税" 零税率标识：需传“2”
    /// 3、当税率为：0%，且增值税特殊管理：为空 零税率标识：需传“3”（全电发票时为空）
    /// </summary>
    [JsonPropertyName("zeroRateFlag")]
    [JsonProperty("zeroRateFlag")]
    public string ZeroRateFlag { get; set; }

}