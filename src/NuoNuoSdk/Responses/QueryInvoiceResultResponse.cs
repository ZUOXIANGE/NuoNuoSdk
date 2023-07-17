namespace NuoNuoSdk.Responses;

public class QueryInvoiceResultResponse : NuoNuoResponse<List<QueryInvoiceResultDto>>
{

}

public class QueryInvoiceResultDto
{
    /// <summary>
    /// 发票请求流水号
    /// </summary>
    [JsonProperty("serialNo")]
    public string SerialNo { get; set; }

    /// <summary>
    /// 订单编号
    /// </summary>
    [JsonProperty("orderNo")]
    public string OrderNo { get; set; }

    /// <summary>
    /// 发票状态：2:开票完成（最终状态），其他状态分别为: 20:开票中; 21:开票成功签章中; 22:开票失败; 24:开票成功签章失败; 3:发票已作废 31:发票作废中 备注：22、24状态时，无需再查询，请确认开票失败原因以及签章失败原因； 注：请以该状态码区分发票状态
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    /// <summary>
    /// 发票状态描述
    /// </summary>
    [JsonProperty("statusMsg")]
    public string StatusMsg { get; set; }

    /// <summary>
    /// 失败原因
    /// </summary>
    [JsonProperty("failCause")]
    public string FailCause { get; set; }

    /// <summary>
    /// 发票pdf地址（若同时返回了ofdUrl与pdfUrl，则pdf文件不能做为原始凭证，请用ofd文件做为原始凭证）
    /// </summary>
    [JsonProperty("pdfUrl")]
    public string PdfUrl { get; set; }

    /// <summary>
    /// 发票图片地址
    /// </summary>
    [JsonProperty("pictureUrl")]
    public string PictureUrl { get; set; }

    /// <summary>
    /// 开票时间
    /// </summary>
    [JsonProperty("invoiceTime")]
    public long InvoiceTime { get; set; }

    /// <summary>
    /// 发票代码（数电票时为空，数电票时有值）
    /// </summary>
    [JsonProperty("invoiceCode")]
    public string InvoiceCode { get; set; }

    /// <summary>
    /// 发票号码（数电票时返回原来的20位数电票号码，数电纸票时为8位的纸票号码）
    /// </summary>
    [JsonProperty("invoiceNo")]
    public string InvoiceNo { get; set; }

    /// <summary>
    /// 数电票号码（数电电票、数电纸票时均返回20位数电票号码）
    /// </summary>
    [JsonProperty("allElectronicInvoiceNumber")]
    public string AllElectronicInvoiceNumber { get; set; }

    /// <summary>
    /// 不含税金额
    /// </summary>
    [JsonProperty("exTaxAmount")]
    public string ExTaxAmount { get; set; }

    /// <summary>
    /// 合计税额
    /// </summary>
    [JsonProperty("taxAmount")]
    public string TaxAmount { get; set; }

    /// <summary>
    /// 价税合计
    /// </summary>
    [JsonProperty("orderAmount")]
    public string OrderAmount { get; set; }

    /// <summary>
    /// 购方名称（付款方名称）
    /// </summary>
    [JsonPropertyName("payerName")]
    [JsonProperty("payerName")]
    public string PayerName { get; set; }

    /// <summary>
    /// 购方税号（付款方税号）
    /// </summary>
    [JsonPropertyName("payerTaxNo")]
    [JsonProperty("payerTaxNo")]
    public string PayerTaxNo { get; set; }

    /// <summary>
    /// 购方地址
    /// </summary>
    [JsonPropertyName("address")]
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// 购方电话
    /// </summary>
    [JsonPropertyName("telephone")]
    [JsonProperty("telephone")]
    public string Telephone { get; set; }

    /// <summary>
    /// 购方开户行及账号
    /// </summary>
    [JsonPropertyName("bankAccount")]
    [JsonProperty("bankAccount")]
    public string BankAccount { get; set; }

    /// <summary>
    /// 发票种类
    /// </summary>
    [JsonPropertyName("invoiceKind")]
    [JsonProperty("invoiceKind")]
    public string InvoiceKind { get; set; }

    /// <summary>
    /// 校验码
    /// </summary>
    [JsonPropertyName("checkCode")]
    [JsonProperty("checkCode")]
    public string CheckCode { get; set; }

    /// <summary>
    /// 二维码
    /// </summary>
    [JsonPropertyName("qrCode")]
    [JsonProperty("qrCode")]
    public string QrCode { get; set; }

    /// <summary>
    /// 税控设备号（机器编码）
    /// </summary>
    [JsonPropertyName("machineCode")]
    [JsonProperty("machineCode")]
    public string MachineCode { get; set; }

    /// <summary>
    /// 发票密文
    /// </summary>
    [JsonPropertyName("cipherText")]
    [JsonProperty("cipherText")]
    public string CipherText { get; set; }

    /// <summary>
    /// 含底图纸票pdf地址
    /// </summary>
    [JsonPropertyName("paperPdfUrl")]
    [JsonProperty("paperPdfUrl")]
    public string PaperPdfUrl { get; set; }

    /// <summary>
    /// 发票ofd地址（公共服务平台签章时返回）
    /// </summary>
    [JsonPropertyName("ofdUrl")]
    [JsonProperty("ofdUrl")]
    public string OfdUrl { get; set; }

    /// <summary>
    /// 发票xml地址（数电电票且企业配置成支持获取xml时返回）
    /// </summary>
    [JsonPropertyName("xmlUrl")]
    [JsonProperty("xmlUrl")]
    public string XmlUrl { get; set; }

    /// <summary>
    /// 开票员
    /// </summary>
    [JsonPropertyName("clerk")]
    [JsonProperty("clerk")]
    public string Clerk { get; set; }

    /// <summary>
    /// 收款人
    /// </summary>
    [JsonPropertyName("payee")]
    [JsonProperty("payee")]
    public string Payee { get; set; }

    /// <summary>
    /// 复核人
    /// </summary>
    [JsonPropertyName("checker")]
    [JsonProperty("checker")]
    public string Checker { get; set; }

    /// <summary>
    /// 销方银行账号
    /// </summary>
    [JsonPropertyName("salerAccount")]
    [JsonProperty("salerAccount")]
    public string SalerAccount { get; set; }

    /// <summary>
    /// 销方电话
    /// </summary>
    [JsonPropertyName("salerTel")]
    [JsonProperty("salerTel")]
    public string SalerTel { get; set; }

    /// <summary>
    /// 销方地址
    /// </summary>
    [JsonPropertyName("salerAddress")]
    [JsonProperty("salerAddress")]
    public string SalerAddress { get; set; }

    /// <summary>
    /// 销方税号
    /// </summary>
    [JsonPropertyName("salerTaxNum")]
    [JsonProperty("salerTaxNum")]
    public string SalerTaxNum { get; set; }

    /// <summary>
    /// 销方名称
    /// </summary>
    [JsonPropertyName("saleName")]
    [JsonProperty("saleName")]
    public string SaleName { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [JsonPropertyName("remark")]
    [JsonProperty("remark")]
    public string Remark { get; set; }

    /// <summary>
    /// 成品油标志
    /// </summary>
    [JsonPropertyName("productOilFlag")]
    [JsonProperty("productOilFlag")]
    public string ProductOilFlag { get; set; }

    /// <summary>
    /// 图片地址（多个图片以逗号隔开）
    /// </summary>
    [JsonPropertyName("imgUrls")]
    public string ImgUrls { get; set; }

    /// <summary>
    /// 分机号
    /// </summary>
    [JsonPropertyName("extensionNumber")]
    public string ExtensionNumber { get; set; }

    /// <summary>
    /// 终端号
    /// </summary>
    [JsonPropertyName("terminalNumber")]
    public string TerminalNumber { get; set; }

    /// <summary>
    /// 部门门店id（诺诺系统中的id）
    /// </summary>
    [JsonPropertyName("deptId")]
    public string DepartmentId { get; set; }

    /// <summary>
    /// 开票员id（诺诺系统中的id）
    /// </summary>
    [JsonPropertyName("clerkId")]
    public string ClerkId { get; set; }

    /// <summary>
    /// 对应蓝票发票代码，红票时有值（蓝票为数电电票时为空，数电纸票时有值）
    /// </summary>
    [JsonPropertyName("oldInvoiceCode")]
    public string OldInvoiceCode { get; set; }

    /// <summary>
    /// 对应蓝票发票号码，红票时有值（蓝票为数电电票时返回原来的20位数电票号码，数电纸票时为8位的纸票号码）
    /// </summary>
    [JsonPropertyName("oldInvoiceNo")]
    public string OldInvoiceNo { get; set; }

    /// <summary>
    /// 对应蓝票数电票号码，红票时有值（蓝票为数电票（电票+纸票）时 20位）
    /// </summary>
    [JsonPropertyName("oldEleInvoiceNumber")]
    public string OldEleInvoiceNumber { get; set; }

    /// <summary>
    /// 清单标志:0,非清单;1,清单票
    /// </summary>
    [JsonPropertyName("listFlag")]
    public string ListFlag { get; set; }

    /// <summary>
    /// 清单项目名称:打印清单时对应发票票面项目名称，注意：税总要求清单项目名称为（详见销货清单）
    /// </summary>
    [JsonPropertyName("listName")]
    public string ListName { get; set; }

    /// <summary>
    /// 购方手机(开票成功会短信提醒购方)
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    /// <summary>
    /// 购方邮箱推送邮箱(开票成功会邮件提醒购方)
    /// </summary>
    [JsonPropertyName("notifyEmail")]
    public string NotifyEmail { get; set; }

    /// <summary>
    /// 是否机动车类专票 0-否 1-是
    /// </summary>
    [JsonPropertyName("vehicleFlag")]
    public int VehicleFlag { get; set; }

    /// <summary>
    /// 数据创建时间（回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("createTime")]
    public string CreateTime { get; set; }

    /// <summary>
    /// 数据更新时间（回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; }

    /// <summary>
    /// 发票状态更新时间（回传其他信息时返回；涉及状态：开票中、开票失败、开票成功签章中、开票成功签章失败、开票完成、发票作废中、发票已作废）
    /// </summary>
    [JsonPropertyName("stateUpdateTime")]
    public string StateUpdateTime { get; set; }

    /// <summary>
    /// 代开标志 0-非代开 1-代开（回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("proxyInvoiceFlag")]
    public string ProxyInvoiceFlag { get; set; }

    /// <summary>
    /// 用于开票的订单的时间（回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("invoiceDate")]
    public string InvoiceDate { get; set; }

    /// <summary>
    /// 开票类型 1-蓝票 2-红票（回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("invoiceType")]
    public int InvoiceType { get; set; }

    /// <summary>
    /// 冲红原因 1:销货退回;2:开票有误;3:服务中止;4:发生销售折让（红票且票种为p、c、e、f、r（成品油发票除外）且回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("redReason")]
    public string RedReason { get; set; }

    /// <summary>
    /// 作废时间（已作废状态下的发票，且回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("invalidTime")]
    public string InvalidTime { get; set; }

    /// <summary>
    /// 作废来源 1-诺诺工作台 2-API接口 3-开票软件 4-验签失败作废 5-其他（已作废状态下的发票，且回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("invalidSource")]
    public int InvalidSource { get; set; }

    /// <summary>
    /// 数电纸票作废原因 1:销货退回;2:开票有误;3:服务中止;4:其他（已作废状态下的发票，且票为数电纸票且回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("invalidReason")]
    public string InvalidReason { get; set; }

    /// <summary>
    /// 其他作废原因详情（作废原因为4 且回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("specificReason")]
    public string SpecificReason { get; set; }

    /// <summary>
    /// 发票特定要素：（后续枚举值会有扩展，回传其他信息时返回）0-普通 1-成品油发票 31-建安发票 32-房地产销售发票 35-矿产品发票
    /// </summary>
    [JsonPropertyName("specificFactor")]
    public int SpecificFactor { get; set; }

    /// <summary>
    /// 邮箱交付状态（0-未交付，1-交付成功，2-交付失败，3-交付中，4-不会交付；回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("emailNotifyStatus")]
    public string EmailNotifyStatus { get; set; }

    /// <summary>
    /// 手机交付状态（0-未交付，1-交付成功，2-交付失败，3-交付中，4-不会交付；回传其他信息时返回）
    /// </summary>
    [JsonPropertyName("phoneNotifyStatus")]
    public string PhoneNotifyStatus { get; set; }

    /// <summary>
    /// 购买方经办人姓名（数电票特有字段）
    /// </summary>
    [JsonPropertyName("buyerManagerName")]
    public string BuyerManagerName { get; set; }

    /// <summary>
    /// 经办人证件类型
    /// </summary>
    [JsonPropertyName("managerCardType")]
    public int ManagerCardType { get; set; }

    /// <summary>
    /// 经办人证件号码（数电票特有字段）
    /// </summary>
    [JsonPropertyName("managerCardNo")]
    public string ManagerCardNo { get; set; }

    /// <summary>
    /// 发票明细集合
    /// </summary>
    [JsonPropertyName("invoiceItems")]
    [JsonProperty("invoiceItems")]
    public List<Dictionary<string, string>> InvoiceItems { get; set; }
}