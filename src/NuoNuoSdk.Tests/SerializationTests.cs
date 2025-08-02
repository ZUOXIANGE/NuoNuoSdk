using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;
using NuoNuoSdk.Requests;
using NuoNuoSdk.Responses;
using NuoNuoSdk;

namespace NuoNuoSdk.Tests;

public class SerializationTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNameCaseInsensitive = true,
        Converters = { new DateTimeConverter(), new NullableDateTimeConverter() }
    };

    [Fact]
    public void BasicSerialization_ShouldUseCorrectPropertyNames()
    {
        // Arrange
        var testObject = new
        {
            OrderNo = "TEST001",
            InvoiceDate = new DateTime(2024, 12, 25, 15, 30, 45),
            BuyerName = "测试买方"
        };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"orderNo\":\"TEST001\"", json);
        Assert.Contains("\"invoiceDate\":\"2024-12-25 15:30:45\"", json);
        Assert.Contains("\"buyerName\":", json);
        // Unicode escaped Chinese characters
        Assert.Contains("\\u6D4B\\u8BD5\\u4E70\\u65B9", json);
    }

    [Fact]
    public void BasicDeserialization_ShouldParseCorrectly()
    {
        // Arrange
        var json = @"{
            ""orderNo"": ""TEST001"",
            ""invoiceDate"": ""2024-12-25 15:30:45"",
            ""buyerName"": ""测试买方""
        }";

        // Act
        var result = JsonSerializer.Deserialize<TestOrderModel>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("TEST001", result.OrderNo);
        Assert.Equal(new DateTime(2024, 12, 25, 15, 30, 45), result.InvoiceDate);
        Assert.Equal("测试买方", result.BuyerName);
    }

    [Fact]
    public void MerchantTokenResponse_Deserialize_ShouldParseCorrectly()
    {
        // Arrange
        var json = @"{
            ""access_token"": ""test_access_token"",
            ""expires_in"": 7200
        }";

        // Act
        var result = JsonSerializer.Deserialize<MerchantTokenResponse>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal("test_access_token", result.AccessToken);
        Assert.Equal(7200, result.ExpiresIn);
    }

    [Fact]
    public void DateTimeSerialization_WithCustomConverter_ShouldUseCorrectFormat()
    {
        // Arrange
        var testObject = new
        {
            TestDate = new DateTime(2024, 12, 25, 15, 30, 45)
        };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"2024-12-25 15:30:45\"", json);
    }

    [Fact]
    public void JsonOptions_Configuration_ShouldBeCorrect()
    {
        // Assert
        Assert.NotNull(_options);
        Assert.Equal(JsonNamingPolicy.CamelCase, _options.PropertyNamingPolicy);
        Assert.Equal(JsonIgnoreCondition.WhenWritingNull, _options.DefaultIgnoreCondition);
        Assert.True(_options.PropertyNameCaseInsensitive);
        Assert.Contains(_options.Converters, c => c is DateTimeConverter);
        Assert.Contains(_options.Converters, c => c is NullableDateTimeConverter);
    }

    [Fact]
    public void NullableDateTime_Serialize_WithNull_ShouldReturnNull()
    {
        // Arrange
        var testObject = new
        {
            NullableDate = (DateTime?)null,
            ValidDate = new DateTime(2024, 12, 25, 15, 30, 45)
        };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"validDate\":\"2024-12-25 15:30:45\"", json);
        // 由于设置了 DefaultIgnoreCondition.WhenWritingNull，null值不会出现在JSON中
        Assert.DoesNotContain("nullableDate", json);
    }

    [Fact]
    public void PropertyNaming_ShouldUseCamelCase()
    {
        // Arrange
        var testObject = new { TestProperty = "test_value" };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"testProperty\"", json);
        Assert.DoesNotContain("\"TestProperty\"", json);
    }

    [Theory]
    [InlineData("2024-12-25 15:30:45")]
    [InlineData("2024-01-01 00:00:00")]
    [InlineData("2023-06-15 12:30:59")]
    public void DateTimeSerialization_RoundTrip_ShouldMaintainValue(string dateString)
    {
        // Arrange
        var originalDate = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", null);
        var testObject = new { TestDate = originalDate };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);
        var deserializedObject = JsonSerializer.Deserialize<TestDateModel>(json, _options);

        // Assert
        Assert.NotNull(deserializedObject);
        Assert.Equal(originalDate, deserializedObject.TestDate);
        Assert.Contains($"\"{dateString}\"", json);
    }
}

public class TestOrderModel
{
    public string? OrderNo { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string? BuyerName { get; set; }
}