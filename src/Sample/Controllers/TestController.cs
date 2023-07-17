using Microsoft.AspNetCore.Mvc;
using NuoNuoSdk;
using NuoNuoSdk.Dtos;
using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;

namespace Sample.Controllers;

/// <summary>
/// Test
/// </summary>
[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly INuoNuoSdk _nuoNuoSdk;

    public TestController(ILogger<TestController> logger, INuoNuoSdk nuoNuoSdk)
    {
        _logger = logger;
        _nuoNuoSdk = nuoNuoSdk;
    }

    [HttpGet("ping")]
    public string Ping() => "pong";

    [HttpGet("nuonuo")]
    public async Task<string> Nuonuo()
    {
        //获取token,根据token有效期自行维护缓存
        var token = await _nuoNuoSdk.GetMerchantTokenAsync();
        _logger.LogInformation("获取token:{token}", token);
        //var token = new MerchantTokenResponse
        //{
        //    AccessToken = ""
        //};

        //查询余票
        var stockRes = await _nuoNuoSdk.ExecuteAsync<GetInvoiceStockRequest, GetInvoiceStockResponse>(new GetInvoiceStockRequest
        {
            AccessToken = token.AccessToken
        });
        _logger.LogInformation("查询余票:{body}", stockRes.Body);

        //开票
        var billingRes = await _nuoNuoSdk.ExecuteAsync<RequestBillingRequest, RequestBillingResponse>(new RequestBillingRequest
        {
            AccessToken = token.AccessToken,
            Order = new OrderDto
            {
                BuyerTaxNum = "6876413SAFDG"
            }
        });
        _logger.LogInformation("开票:{body}", billingRes.Body);

        //查询
        var invoiceRes = await _nuoNuoSdk.ExecuteAsync<QueryInvoiceResultRequest, QueryInvoiceResultResponse>(new QueryInvoiceResultRequest
        {
            AccessToken = token.AccessToken,
            SerialNos = new List<string> { billingRes.Result.InvoiceSerialNum }
        });
        _logger.LogInformation("查询发票:{body}", invoiceRes.Body);

        var r = invoiceRes.Result.First();
        //重发
        var deliveryInvoiceRes = await _nuoNuoSdk.ExecuteAsync<DeliveryInvoiceRequest, NuoNuoResponse>(new DeliveryInvoiceRequest
        {
            AccessToken = token.AccessToken,
            InvoiceCode = r.InvoiceCode,
            InvoiceNumber = r.InvoiceNo,
            TaxNumber = r.SalerTaxNum,
            Mail = "zuoxiang42@gmail.com",
            Phone = ""
        });
        _logger.LogInformation("重发发票:{body}", deliveryInvoiceRes.Body);

        //作废
        var cancellationRes = await _nuoNuoSdk.ExecuteAsync<InvoiceCancellationRequest, InvoiceCancellationResponse>(new InvoiceCancellationRequest
        {
            AccessToken = token.AccessToken,
            InvoiceId = billingRes.Result.InvoiceSerialNum,
            InvoiceCode = r.InvoiceCode,
            InvoiceNo = r.InvoiceNo
        });
        _logger.LogInformation("发票作废:{body}", cancellationRes.Body);

        return "测试完成";
    }

}