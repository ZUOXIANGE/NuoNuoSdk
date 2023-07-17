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
        //��ȡtoken,����token��Ч������ά������
        var token = await _nuoNuoSdk.GetMerchantTokenAsync();
        _logger.LogInformation("��ȡtoken:{token}", token);
        //var token = new MerchantTokenResponse
        //{
        //    AccessToken = ""
        //};

        //��ѯ��Ʊ
        var stockRes = await _nuoNuoSdk.ExecuteAsync<GetInvoiceStockRequest, GetInvoiceStockResponse>(new GetInvoiceStockRequest
        {
            AccessToken = token.AccessToken
        });
        _logger.LogInformation("��ѯ��Ʊ:{body}", stockRes.Body);

        //��Ʊ
        var billingRes = await _nuoNuoSdk.ExecuteAsync<RequestBillingRequest, RequestBillingResponse>(new RequestBillingRequest
        {
            AccessToken = token.AccessToken,
            Order = new OrderDto
            {
                BuyerTaxNum = "6876413SAFDG"
            }
        });
        _logger.LogInformation("��Ʊ:{body}", billingRes.Body);

        //��ѯ
        var invoiceRes = await _nuoNuoSdk.ExecuteAsync<QueryInvoiceResultRequest, QueryInvoiceResultResponse>(new QueryInvoiceResultRequest
        {
            AccessToken = token.AccessToken,
            SerialNos = new List<string> { billingRes.Result.InvoiceSerialNum }
        });
        _logger.LogInformation("��ѯ��Ʊ:{body}", invoiceRes.Body);

        var r = invoiceRes.Result.First();
        //�ط�
        var deliveryInvoiceRes = await _nuoNuoSdk.ExecuteAsync<DeliveryInvoiceRequest, NuoNuoResponse>(new DeliveryInvoiceRequest
        {
            AccessToken = token.AccessToken,
            InvoiceCode = r.InvoiceCode,
            InvoiceNumber = r.InvoiceNo,
            TaxNumber = r.SalerTaxNum,
            Mail = "zuoxiang42@gmail.com",
            Phone = ""
        });
        _logger.LogInformation("�ط���Ʊ:{body}", deliveryInvoiceRes.Body);

        //����
        var cancellationRes = await _nuoNuoSdk.ExecuteAsync<InvoiceCancellationRequest, InvoiceCancellationResponse>(new InvoiceCancellationRequest
        {
            AccessToken = token.AccessToken,
            InvoiceId = billingRes.Result.InvoiceSerialNum,
            InvoiceCode = r.InvoiceCode,
            InvoiceNo = r.InvoiceNo
        });
        _logger.LogInformation("��Ʊ����:{body}", cancellationRes.Body);

        return "�������";
    }

}