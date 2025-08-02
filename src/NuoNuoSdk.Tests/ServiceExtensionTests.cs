using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Xunit;
using NuoNuoSdk;

namespace NuoNuoSdk.Tests;

public class ServiceExtensionTests
{
    [Fact]
    public void AddNuoNuoSdk_WithValidOptions_ShouldRegisterServices()
    {
        // Arrange
        var services = new ServiceCollection();
        var options = new NuoNuoOptions
        {
            AppKey = "test_app_key",
            AppSecret = "test_app_secret"
        };

        // Act
        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = options.AppKey;
            opt.AppSecret = options.AppSecret;
        });

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var nuoNuoSdk = serviceProvider.GetService<INuoNuoSdk>();
        Assert.NotNull(nuoNuoSdk);

        var optionsFromContainer = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
        Assert.NotNull(optionsFromContainer);
        Assert.Equal(options.AppKey, optionsFromContainer.Value.AppKey);
        Assert.Equal(options.AppSecret, optionsFromContainer.Value.AppSecret);

    }

    [Fact]
    public void AddNuoNuoSdk_ShouldRegisterHttpClient()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = "test_app_key";
            opt.AppSecret = "test_app_secret";
        });

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        Assert.NotNull(httpClientFactory);

        var httpClient = httpClientFactory.CreateClient("NuoNuoSdk");
        Assert.NotNull(httpClient);
    }

    [Fact]
    public void AddNuoNuoSdk_ShouldRegisterAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = "test_app_key";
            opt.AppSecret = "test_app_secret";
        });

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var instance1 = serviceProvider.GetService<INuoNuoSdk>();
        var instance2 = serviceProvider.GetService<INuoNuoSdk>();
        
        Assert.NotNull(instance1);
        Assert.NotNull(instance2);
        Assert.Same(instance1, instance2); // 应该是同一个实例
    }

    [Fact]
    public void AddNuoNuoSdk_WithNullAction_ShouldThrowException()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => services.AddNuoNuoSdk(null!));
    }

    [Fact]
    public void AddNuoNuoSdk_WithEmptyOptions_ShouldStillRegister()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddNuoNuoSdk(opt => { }); // 空配置

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var nuoNuoSdk = serviceProvider.GetService<INuoNuoSdk>();
        Assert.NotNull(nuoNuoSdk);

        var options = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
        Assert.NotNull(options);
        Assert.NotNull(options.Value);
    }

    [Fact]
    public void AddNuoNuoSdk_MultipleRegistrations_ShouldUseLastConfiguration()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = "first_key";
            opt.AppSecret = "first_secret";
        });

        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = "second_key";
            opt.AppSecret = "second_secret";
        });

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var options = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
        Assert.NotNull(options);
        Assert.Equal("second_key", options.Value.AppKey);
        Assert.Equal("second_secret", options.Value.AppSecret);
    }

    [Fact]
    public void AddNuoNuoSdk_WithValidConfiguration_ShouldConfigureCorrectly()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddNuoNuoSdk(opt =>
        {
            opt.AppKey = "test_key";
            opt.AppSecret = "test_secret";
        });

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var options = serviceProvider.GetService<IOptions<NuoNuoOptions>>();
        Assert.NotNull(options);
        Assert.Equal("test_key", options.Value.AppKey);
        Assert.Equal("test_secret", options.Value.AppSecret);
    }
}