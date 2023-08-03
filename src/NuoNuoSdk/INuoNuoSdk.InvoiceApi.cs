using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;

namespace NuoNuoSdk;

/// <summary>
/// 诺诺开放平台SDK-电子发票相关API
/// </summary>
public partial interface INuoNuoSdk
{
    /// <summary>
    /// 企业发票余量查询接口
    /// <para>企业发票库存查询接口： 都传入的时候，各参数优先级：分机号>机器编号>分机号+机器编号的联合查询>部门ID</para>
    /// </summary>
    /// <param name="request"><see cref="GetInvoiceStockRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="GetInvoiceStockResponse"/></returns>
    Task<GetInvoiceStockResponse> GetInvoiceStockAsync(GetInvoiceStockRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<GetInvoiceStockRequest, GetInvoiceStockResponse>(request, options, enableLog);

    /// <summary>
    /// 请求开具发票接口(2.0)
    /// <para>具备诺诺发票资质的企业用户（服务商身份需要申请接口授权）填写诺诺发票销方、购方、明细等信息并发起开票请求。</para>
    /// </summary>
    /// <param name="request"><see cref="RequestBillingRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="RequestBillingResponse"/></returns>
    Task<RequestBillingResponse> RequestBillingRequest(RequestBillingRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<RequestBillingRequest, RequestBillingResponse>(request, options, enableLog);

    /// <summary>
    /// 开票结果查询接口
    /// <para>调用该接口获取发票开票结果等有关发票信息，部分字段需要配置才返回</para>
    /// </summary>
    /// <param name="request"><see cref="QueryInvoiceResultRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="QueryInvoiceResultResponse"/></returns>
    Task<QueryInvoiceResultResponse> QueryInvoiceResultAsync(QueryInvoiceResultRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<QueryInvoiceResultRequest, QueryInvoiceResultResponse>(request, options, enableLog);

    /// <summary>
    /// 开票重试接口
    /// <para>发票开票失败时，可使用该接口进行重推开票，发票订单号、流水号与原请求一致 1、对于开票成功状态的发票（发票生成、开票完成），调用该接口，提示：发票已生成，无需再重试开票 2、对于开票中状态的发票，调用该接口，提示：开票中（重试中），请耐心等待开票结果</para>
    /// </summary>
    /// <param name="request"><see cref="ReInvoiceRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="ReInvoiceResponse"/></returns>
    Task<ReInvoiceResponse> ReInvoiceAsync(ReInvoiceRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<ReInvoiceRequest, ReInvoiceResponse>(request, options, enableLog);

    /// <summary>
    /// 发票重新交付接口
    /// <para>通过该接口重新交付平台开具的发票至消费者短信、邮箱</para>
    /// </summary>
    /// <param name="request"><see cref="DeliveryInvoiceRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="DeliveryInvoiceResponse"/></returns>
    Task<DeliveryInvoiceResponse> DeliveryInvoiceAsync(DeliveryInvoiceRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<DeliveryInvoiceRequest, DeliveryInvoiceResponse>(request, options, enableLog);

    /// <summary>
    /// 发票作废接口
    /// <para>用户作废已开票成功的发票</para>
    /// </summary>
    /// <param name="request"><see cref="InvoiceCancellationRequest"/></param>
    /// <param name="options"></param>
    /// <param name="enableLog"></param>
    /// <returns><see cref="InvoiceCancellationResponse"/></returns>
    Task<InvoiceCancellationResponse> InvoiceCancellationAsync(InvoiceCancellationRequest request, NuoNuoOptions options = null, bool enableLog = true)
        => ExecuteAsync<InvoiceCancellationRequest, InvoiceCancellationResponse>(request, options, enableLog);

}