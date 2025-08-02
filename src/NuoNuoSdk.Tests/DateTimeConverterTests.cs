using System.Text.Json;
using Xunit;

namespace NuoNuoSdk.Tests;

public class DateTimeConverterTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        Converters = { new DateTimeConverter(), new NullableDateTimeConverter() }
    };

    [Fact]
    public void DateTimeConverter_Serialize_ShouldReturnCorrectFormat()
    {
        // Arrange
        var dateTime = new DateTime(2024, 12, 25, 15, 30, 45);
        var testObject = new { TestDate = dateTime };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"2024-12-25 15:30:45\"", json);
    }

    [Fact]
    public void DateTimeConverter_Deserialize_ShouldParseCorrectFormat()
    {
        // Arrange
        var json = "{\"TestDate\":\"2024-12-25 15:30:45\"}";

        // Act
        var result = JsonSerializer.Deserialize<TestDateModel>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2024, 12, 25, 15, 30, 45), result.TestDate);
    }

    [Fact]
    public void DateTimeConverter_Deserialize_InvalidFormat_ShouldFallbackToDefault()
    {
        // Arrange
        var json = "{\"TestDate\":\"2024-12-25T15:30:45\"}";

        // Act
        var result = JsonSerializer.Deserialize<TestDateModel>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(new DateTime(2024, 12, 25, 15, 30, 45), result.TestDate);
    }

    [Fact]
    public void NullableDateTimeConverter_Serialize_WithValue_ShouldReturnCorrectFormat()
    {
        // Arrange
        var dateTime = new DateTime(2024, 1, 1, 0, 0, 0);
        var testObject = new { TestDate = (DateTime?)dateTime };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("\"2024-01-01 00:00:00\"", json);
    }

    [Fact]
    public void NullableDateTimeConverter_Serialize_WithNull_ShouldReturnNull()
    {
        // Arrange
        var testObject = new { TestDate = (DateTime?)null };

        // Act
        var json = JsonSerializer.Serialize(testObject, _options);

        // Assert
        Assert.Contains("null", json);
    }

    [Fact]
    public void NullableDateTimeConverter_Deserialize_WithValue_ShouldParseCorrectly()
    {
        // Arrange
        var json = "{\"TestDate\":\"2024-01-01 00:00:00\"}";

        // Act
        var result = JsonSerializer.Deserialize<TestNullableDateModel>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.TestDate);
        Assert.Equal(new DateTime(2024, 1, 1, 0, 0, 0), result.TestDate.Value);
    }

    [Fact]
    public void NullableDateTimeConverter_Deserialize_WithNull_ShouldReturnNull()
    {
        // Arrange
        var json = "{\"TestDate\":null}";

        // Act
        var result = JsonSerializer.Deserialize<TestNullableDateModel>(json, _options);

        // Assert
        Assert.NotNull(result);
        Assert.Null(result.TestDate);
    }

    [Theory]
    [InlineData("2024-12-25 15:30:45")]
    [InlineData("2024-01-01 00:00:00")]
    [InlineData("2023-06-15 12:30:59")]
    public void DateTimeConverter_RoundTrip_ShouldMaintainValue(string dateString)
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
    }
}

public class TestDateModel
{
    public DateTime TestDate { get; set; }
}

public class TestNullableDateModel
{
    public DateTime? TestDate { get; set; }
}