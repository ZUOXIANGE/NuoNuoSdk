using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using NuoNuoSdk;

namespace Sample.Controllers;

/// <summary>
/// 日期序列化测试控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class DateTestController : ControllerBase
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        Converters = { new DateTimeConverter(), new NullableDateTimeConverter() }
    };

    /// <summary>
    /// 测试日期序列化格式
    /// </summary>
    /// <returns>包含各种日期格式的测试数据</returns>
    [HttpGet("test")]
    public IActionResult TestDateSerialization()
    {
        var testData = new
        {
            CurrentTime = DateTime.Now,
            UtcTime = DateTime.UtcNow,
            SpecificDate = new DateTime(2024, 12, 25, 15, 30, 45),
            NullableDate = (DateTime?)new DateTime(2024, 1, 1, 0, 0, 0),
            NullDate = (DateTime?)null
        };

        // 使用自定义的JsonOptions序列化
        string json = JsonSerializer.Serialize(testData, JsonOptions);

        return Ok(new
        {
            Message = "日期序列化测试",
            Format = "yyyy-MM-dd HH:mm:ss",
            SerializedJson = json,
            Data = testData
        });
    }

    /// <summary>
    /// 测试日期反序列化
    /// </summary>
    /// <param name="dateString">日期字符串</param>
    /// <returns>解析结果</returns>
    [HttpPost("parse")]
    public IActionResult TestDateDeserialization([FromBody] string dateString)
    {
        try
        {
            var testJson = $"{{\"testDate\": \"{dateString}\"}}";
            var result = JsonSerializer.Deserialize<TestDateModel>(testJson, JsonOptions);

            return Ok(new
            {
                Input = dateString,
                ParsedDate = result!.TestDate,
                Success = true
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Input = dateString,
                Error = ex.Message,
                Success = false
            });
        }
    }
}

public class TestDateModel
{
    public DateTime TestDate { get; set; }
}