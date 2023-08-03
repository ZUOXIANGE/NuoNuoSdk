namespace NuoNuoSdk.Requests;

/// <summary>
/// 请求开具发票(2.0)请求
/// </summary>
public class RequestBillingRequest : NuoNuoRequest
{
    public override string Method => "nuonuo.ElectronInvoice.requestBillingNew";

    /// <summary>
    /// Order
    /// </summary>
    [JsonPropertyName("order")]
    [JsonProperty("order")]
    public OrderDto Order { get; set; }
}

public class OrderDto
{
    /// <summary>
    /// 购方名称
    /// </summary>
    [JsonPropertyName("buyerName")]
    [JsonProperty("buyerName")]
    public string BuyerName { get; set; }

    /// <summary>
    /// 购方税号（企业要填，个人可为空；二手车销售统一发票时必填）
    /// </summary>
    [JsonPropertyName("buyerTaxNum")]
    [JsonProperty("buyerTaxNum")]
    public string BuyerTaxNum { get; set; }

    /// <summary>
    /// 购方电话（购方地址+电话总共不超100字符；二手车销售统一发票时必填）
    /// </summary>
    [JsonPropertyName("buyerTel")]
    [JsonProperty("buyerTel")]
    public string BuyerTel { get; set; }

    /// <summary>
    /// 购方地址（购方地址+电话总共不超100字符；二手车销售统一发票时必填）
    /// </summary>
    [JsonPropertyName("buyerAddress")]
    [JsonProperty("buyerAddress")]
    public string BuyerAddress { get; set; }

    /// <summary>
    /// 购方银行开户行及账号
    /// </summary>
    [JsonPropertyName("buyerAccount")]
    [JsonProperty("buyerAccount")]
    public string BuyerAccount { get; set; }

    /// <summary>
    /// 销方税号（使用沙箱环境请求时消息体参数salerTaxNum和消息头参数userTax填写339902999999789113）
    /// </summary>
    [JsonPropertyName("salerTaxNum")]
    [JsonProperty("salerTaxNum")]
    public string SalerTaxNum { get; set; }

    /// <summary>
    /// 销方电话（若已在诺诺工作台配置过可以不传，以传入为准）
    /// </summary>
    [JsonPropertyName("salerTel")]
    [JsonProperty("salerTel")]
    public string SalerTel { get; set; }

    /// <summary>
    /// 销方地址（若已在诺诺工作台配置过可以不传，以传入为准）
    /// </summary>
    [JsonPropertyName("salerAddress")]
    [JsonProperty("salerAddress")]
    public string SalerAddress { get; set; }

    /// <summary>
    /// 销方银行开户行及账号(二手车销售统一发票时必填)
    /// </summary>
    [JsonPropertyName("salerAccount")]
    [JsonProperty("salerAccount")]
    public string SalerAccount { get; set; }

    /// <summary>
    /// 订单号（每个企业唯一）
    /// </summary>
    [JsonPropertyName("orderNo")]
    [JsonProperty("orderNo")]
    public string OrderNo { get; set; }

    /// <summary>
    /// 订单时间
    /// </summary>
    [JsonProperty("invoiceDate")]
    [JsonPropertyName("invoiceDate")]
    public string InvoiceDate { get; set; }

    /// <summary>
    /// 冲红时填写的对应蓝票发票代码（红票必填10位或12位，11位的时候请左补0）
    /// </summary>
    [JsonProperty("invoiceCode")]
    [JsonPropertyName("invoiceCode")]
    public string InvoiceCode { get; set; }

    /// <summary>
    /// 冲红时填写的对应蓝票发票号码（红票必填，不满8位请左补0）
    /// </summary>
    [JsonProperty("invoiceNum")]
    [JsonPropertyName("invoiceNum")]
    public string InvoiceNum { get; set; }

    /// <summary>
    /// 冲红原因：1:销货退回;2:开票有误;3:服务中止;4:发生销售折让(开具红票时且票种为p,c,e,f,r需要传--成品油发票除外；不传时默认为1)
    /// </summary>
    [JsonProperty("redReason")]
    [JsonPropertyName("redReason")]
    public string RedReason { get; set; }

    /// <summary>
    /// 红字信息表编号.专票冲红时此项必填，且必须在备注中注明“开具红字增值税专用发票信息表编号ZZZZZZZZZZZZZZZZ”字样，
    /// 其中“Z”为开具红字增值税专用发票所需要的长度为16位信息表编号（建议16位，最长可支持24位）。
    /// </summary>
    [JsonProperty("billInfoNo")]
    [JsonPropertyName("billInfoNo")]
    public string BillInfoNo { get; set; }

    /// <summary>
    /// 部门门店id（诺诺系统中的id）
    /// </summary>
    [JsonProperty("departmentId")]
    [JsonPropertyName("departmentId")]
    public string DepartmentId { get; set; }

    /// <summary>
    /// 开票员id（诺诺系统中的id）
    /// </summary>
    [JsonProperty("clerkId")]
    [JsonPropertyName("clerkId")]
    public string ClerkId { get; set; }

    /// <summary>
    /// 冲红时，在备注中注明“对应正数发票代码:XXXXXXXXX号码:YYYYYYYY”文案，
    /// 其中“X”为发票代码，“Y”为发票号码，可以不填，接口会自动添加该文案；
    /// 机动车发票蓝票时备注只能为空
    /// </summary>
    [JsonProperty("remark")]
    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    /// <summary>
    /// 复核人
    /// </summary>
    [JsonProperty("checker")]
    [JsonPropertyName("checker")]
    public string Checker { get; set; }

    /// <summary>
    /// 收款人
    /// </summary>
    [JsonProperty("payee")]
    [JsonPropertyName("payee")]
    public string Payee { get; set; }

    /// <summary>
    /// 开票员
    /// </summary>
    [JsonProperty("clerk")]
    [JsonPropertyName("clerk")]
    public string Clerk { get; set; }

    /// <summary>
    /// 清单标志：非清单:0；清单:1，默认:0，电票固定为0
    /// </summary>
    [JsonProperty("listFlag")]
    [JsonPropertyName("listFlag")]
    public string ListFlag { get; set; }

    /// <summary>
    /// 清单项目名称：对应发票票面项目名称（listFlag为1时，必填，默认为“详见销货清单”）
    /// </summary>
    [JsonProperty("listName")]
    [JsonPropertyName("listName")]
    public string ListName { get; set; }

    /// <summary>
    /// 推送方式：-1,不推送;0,邮箱;1,手机（默认）;2,邮箱、手机
    /// </summary>
    [JsonProperty("pushMode")]
    [JsonPropertyName("pushMode")]
    public string PushMode { get; set; }

    /// <summary>
    /// 购方手机（pushMode为1或2时，此项为必填，同时受企业资质是否必填控制）
    /// </summary>
    [JsonProperty("buyerPhone")]
    [JsonPropertyName("buyerPhone")]
    public string BuyerPhone { get; set; }

    /// <summary>
    /// 推送邮箱（pushMode为0或2时，此项为必填，同时受企业资质是否必填控制）
    /// </summary>
    [JsonProperty("email")]
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// 开票类型：1:蓝票;2:红票
    /// </summary>
    [JsonProperty("invoiceType")]
    [JsonPropertyName("invoiceType")]
    public string InvoiceType { get; set; }

    /// <summary>
    /// 发票种类：p,普通发票(电票)(默认);c,普通发票(纸票);s,专用发票;e,收购发票(电票);
    /// f,收购发票(纸质);r,普通发票(卷式);b,增值税电子专用发票;j,机动车销售统一发票;u,二手车销售统一发票
    /// </summary>
    [JsonProperty("invoiceLine")]
    [JsonPropertyName("invoiceLine")]
    public string InvoiceLine { get; set; }

    /// <summary>
    /// 特定要素：0普通发票（默认）、1成品油、31建安发票、32房地产销售发票、35矿产品
    /// </summary>
    [JsonProperty("specificFactor")]
    [JsonPropertyName("specificFactor")]
    public string SpecificFactor { get; set; }

    /// <summary>
    /// 代开标志：0非代开;1代开。
    /// 代开蓝票时备注要求填写文案：代开企业税号:***,代开企业名称:***；
    /// 代开红票时备注要求填写文案：对应正数发票代码:***号码:***代开企业税号:***代开企业名称:***
    /// </summary>
    [JsonProperty("proxyInvoiceFlag")]
    [JsonPropertyName("proxyInvoiceFlag")]
    public string ProxyInvoiceFlag { get; set; }

    /// <summary>
    /// 回传发票信息地址（开票完成、开票失败）
    /// </summary>
    [JsonProperty("callBackUrl")]
    [JsonPropertyName("callBackUrl")]
    public string CallBackUrl { get; set; }

    /// <summary>
    /// 分机号（只能为空或者数字）
    /// </summary>
    [JsonProperty("extensionNumber")]
    [JsonPropertyName("extensionNumber")]
    public string ExtensionNumber { get; set; }

    /// <summary>
    /// 终端号（开票终端号，只能 为空或数字）
    /// </summary>
    [JsonPropertyName("terminalNumber")]
    [JsonProperty("terminalNumber")]
    public string TerminalNumber { get; set; }

    /// <summary>
    /// 机器编号（12位盘号）
    /// </summary>
    [JsonProperty("machineCode")]
    [JsonPropertyName("machineCode")]
    public string MachineCode { get; set; }

    /// <summary>
    /// 是否机动车类专票 0-否 1-是
    /// </summary>
    [JsonProperty("vehicleFlag")]
    [JsonPropertyName("vehicleFlag")]
    public string VehicleFlag { get; set; }

    /// <summary>
    /// 是否隐藏编码表版本号0-否1-是（默认0，在企业资质中也配置为是隐藏的时候，并且此字段传1的时候代开发票税率显示***）
    /// </summary>
    [JsonProperty("hiddenBmbbbh")]
    [JsonPropertyName("hiddenBmbbbh")]
    public string HiddenBmbbbh { get; set; }

    /// <summary>
    /// 指定发票代码（票种为c普纸、f收购纸票时支持指定卷开票） 非必填
    /// </summary>
    [JsonProperty("nextInvoiceCode")]
    [JsonPropertyName("nextInvoiceCode")]
    public string NextInvoiceCode { get; set; }

    /// <summary>
    /// 发票起始号码，当指定代码有值时，发票起始号码必填
    /// </summary>
    [JsonProperty("nextInvoiceNum")]
    [JsonPropertyName("nextInvoiceNum")]
    public string NextInvoiceNum { get; set; }

    /// <summary>
    /// 发票终止号码， 当指定代码有值时，发票终止号码必填
    /// </summary>
    [JsonProperty("invoiceNumEnd")]
    [JsonPropertyName("invoiceNumEnd")]
    public string InvoiceNumEnd { get; set; }

    /// <summary>
    /// 3%、1%税率开具理由（企业为小规模/点下户时才需要），对应值：
    /// 1-开具发票为2022年3月31日前发生纳税义务的业务；
    /// 2-前期已开具相应征收率发票，发生销售折让、中止或者退回等情形需要开具红字发票，或者开票有误需要重新开具；
    /// 3-因为实际经营业务需要，放弃享受免征增值税政策
    /// </summary>
    [JsonProperty("surveyAnswerType")]
    [JsonPropertyName("surveyAnswerType")]
    public string SurveyAnswerType { get; set; }

    /// <summary>
    /// 机动车销售统一发票才需要传
    /// </summary>
    [JsonPropertyName("vehicleInfo")]
    [JsonProperty("vehicleInfo")]
    public Dictionary<string, string> VehicleInfo { get; set; }

    /// <summary>
    /// 开具二手车销售统一发票才需要传
    /// </summary>
    [JsonPropertyName("secondHandCarInfo")]
    [JsonProperty("secondHandCarInfo")]
    public Dictionary<string, string> SecondHandCarInfo { get; set; }

    /// <summary>
    /// 发票明细，支持填写商品明细最大2000行（包含折扣行、被折扣行）
    /// </summary>
    [JsonPropertyName("invoiceDetail")]
    [JsonProperty("invoiceDetail")]
    public List<InvoiceDetailDto> InvoiceDetail { get; set; }

}

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