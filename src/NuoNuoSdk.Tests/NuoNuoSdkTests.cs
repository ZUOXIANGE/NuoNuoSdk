using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using Xunit;
using NuoNuoSdk;
using NuoNuoSdk.Responses;

namespace NuoNuoSdk.Tests;

public class NuoNuoSdkTests
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
    private readonly Mock<ILogger<NuoNuoSdk>> _loggerMock;
    private readonly NuoNuoOptions _options;
    private readonly INuoNuoSdk _nuoNuoSdk;

    public NuoNuoSdkTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();
        _httpClientFactoryMock.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(httpClient);
        
        _loggerMock = new Mock<ILogger<NuoNuoSdk>>();
        
        _options = new NuoNuoOptions
        {
            AppKey = "test_app_key",
            AppSecret = "test_app_secret"
        };

        var optionsMock = new Mock<IOptions<NuoNuoOptions>>();
        optionsMock.Setup(x => x.Value).Returns(_options);

        _nuoNuoSdk = new NuoNuoSdk(_httpClientFactoryMock.Object, _loggerMock.Object, optionsMock.Object);
    }

    [Fact]
    public void Constructor_WithValidOptions_ShouldInitialize()
    {
        // Assert
        Assert.NotNull(_nuoNuoSdk);
    }

    [Fact]
    public async Task GetMerchantTokenAsync_WithValidCredentials_ShouldReturnToken()
    {
        // Arrange
        var expectedResponse = new MerchantTokenResponse
        {
            AccessToken = "test_access_token",
            ExpiresIn = 7200
        };
        var responseJson = JsonSerializer.Serialize(expectedResponse);
        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpResponse);

        // Act
        var result = await _nuoNuoSdk.GetMerchantTokenAsync();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Equal("test_access_token", result.AccessToken);
        Assert.Equal(7200, result.ExpiresIn);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GetMerchantTokenAsync_WithInvalidCredentials_ShouldThrowException(string invalidValue)
    {
        // Arrange
        var invalidOptions = new NuoNuoOptions
        {
            AppKey = invalidValue,
            AppSecret = invalidValue
        };

        var httpResponse = new HttpResponseMessage(HttpStatusCode.BadRequest)
        {
            Content = new StringContent("{\"error\":\"invalid_client\"}", Encoding.UTF8, "application/json")
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpResponse);

        // Act
        var result = await _nuoNuoSdk.GetMerchantTokenAsync(invalidOptions);

        // Assert
        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public async Task GetMerchantTokenAsync_WithServerError_ShouldHandleError()
    {
        // Arrange
        var httpResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        {
            Content = new StringContent("{\"error\":\"server_error\"}", Encoding.UTF8, "application/json")
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpResponse);

        // Act
        var result = await _nuoNuoSdk.GetMerchantTokenAsync();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetMerchantTokenAsync_WithTimeout_ShouldThrowException()
    {
        // Arrange
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(new TaskCanceledException());

        // Act & Assert
        await Assert.ThrowsAsync<TaskCanceledException>(() => _nuoNuoSdk.GetMerchantTokenAsync());
    }

    [Fact]
    public async Task GetMerchantTokenAsync_WithInvalidJson_ShouldThrowException()
    {
        // Arrange
        var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("invalid json", Encoding.UTF8, "application/json")
        };

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(httpResponse);

        // Act & Assert
        await Assert.ThrowsAsync<JsonException>(() => _nuoNuoSdk.GetMerchantTokenAsync());
    }
}