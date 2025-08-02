using Microsoft.AspNetCore.Mvc;
using NuoNuoSdk;
using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;

namespace Sample.Controllers;

/// <summary>
/// 诺诺SDK测试控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TestController(ILogger<TestController> logger, INuoNuoSdk nuoNuoSdk) : ControllerBase
{
    private readonly ILogger<TestController> _logger = logger;
    private readonly INuoNuoSdk _nuoNuoSdk = nuoNuoSdk;

    /// <summary>
    /// 健康检查接口
    /// </summary>
    /// <returns>返回pong表示服务正常</returns>
    [HttpGet("ping")]
    public IActionResult Ping() => Ok(new { message = "pong", timestamp = DateTimeOffset.UtcNow });

    /// <summary>
    /// 诺诺SDK完整流程测试
    /// </summary>
    /// <returns>测试结果</returns>
    [HttpGet("nuonuo")]
    public async Task<IActionResult> NuoNuoTestAsync()
    {
        try
        {
            // 获取token，如果token有效期长，建议维护缓存
            var token = await _nuoNuoSdk.GetMerchantTokenAsync();
            _logger.LogInformation("获取token成功: {AccessToken}", token.AccessToken?[..10] + "...");

            if (!token.Success)
            {
                return BadRequest(new { error = "获取token失败", details = token.ErrorDescription });
            }

            // 查询发票余量
            var stockRes = await _nuoNuoSdk.GetInvoiceStockAsync(new GetInvoiceStockRequest
            {
                AccessToken = token.AccessToken
            });
            _logger.LogInformation("查询发票余量: {Success}", stockRes.Success);

            if (!stockRes.Success)
            {
                return BadRequest(new { error = "查询发票余量失败", details = stockRes.Describe });
            }

            // 示例：开票请求（注意：这里使用测试数据，实际使用时需要真实数据）
            var billingRes = await _nuoNuoSdk.RequestBillingRequest(new RequestBillingRequest
            {
                AccessToken = token.AccessToken,
                Order = new OrderDto
                {
                    BuyerTaxNum = "TEST123456789" // 测试税号
                }
            });
            _logger.LogInformation("开票请求: {Success}", billingRes.Success);

            return Ok(new
            {
                message = "测试完成",
                results = new
                {
                    tokenSuccess = token.Success,
                    stockSuccess = stockRes.Success,
                    billingSuccess = billingRes.Success,
                    timestamp = DateTimeOffset.UtcNow
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "诺诺SDK测试过程中发生异常");
            return StatusCode(500, new { error = "测试过程中发生异常", details = ex.Message });
        }
    }

}